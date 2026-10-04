(function() {
    try {
        // 1. 创建样式
        var css = `
            #loading_mask_layer {
                position: fixed;
                top: 0;
                left: 0;
                width: 100%;
                height: 100%;
                min-width: 80px;
                z-index: 9999;
                /* 修改点：背景改为半透明灰色，实现透明显示效果 */
                background: #F0F0F0; 
                opacity: 0.9; /* 0.9 代表 90% 不透明度，网页内容稍微透出来一点 */
                filter: alpha(opacity=90); 
                text-align: center;
                
                /* 可选：添加模糊滤镜，让背景内容更模糊，增强层次感（仅现代浏览器有效） */
                backdrop-filter: blur(5px); 
                -webkit-backdrop-filter: blur(5px);
            }
            #loading_inner_box {
                display: inline-block;
                margin-top: 100px;
                height: 33px;
                line-height: 33px;
                padding: 6px;
                background: transparent;
                font-size: 12px;
                opacity: 0.9;
                font-family: "PingFang SC", "Microsoft YaHei", "Helvetica Neue", Helvetica, Arial, sans-serif;
                font-weight: normal;
                color: #333333; /* 深灰色文字，适配浅色半透明背景 */
                cursor: wait;
            }
        `;
        
        // 2. 注入样式到头部
        var style = document.createElement('style');
        if (style.styleSheet) {
            style.styleSheet.cssText = css;
        } else {
            style.appendChild(document.createTextNode(css));
        }
        var head = document.getElementsByTagName('head')[0];
        if (head) head.appendChild(style);

        // 3. 创建遮罩层 DOM 结构
        var maskDiv = document.createElement('div');
        maskDiv.id = 'loading_mask_layer';
        
        var innerDiv = document.createElement('div');
        innerDiv.id = 'loading_inner_box';
        innerDiv.innerHTML = '⏳ 加载中 Loading...';       
        maskDiv.appendChild(innerDiv);

        // 4. 将遮罩层插入到页面中
        var root = document.body || document.documentElement;
        root.appendChild(maskDiv);

        // 5. 绑定加载完成事件
        var removeMask = function() {
            var el = document.getElementById('loading_mask_layer');
            if (el && el.parentNode) {
                el.parentNode.removeChild(el);
            }
        };

        if (window.addEventListener) {
            window.addEventListener('load', removeMask, false);
        } else if (window.attachEvent) {
            window.attachEvent('onload', removeMask);
        } else {
            window.onload = removeMask; 
        }
    } catch (err) {
        console.log("Loading mask error:", err);
    }
})();
