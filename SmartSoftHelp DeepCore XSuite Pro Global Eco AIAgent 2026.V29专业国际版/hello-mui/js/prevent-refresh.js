// prevent-refresh.js 防频繁刷新 
(function () {
    try {
        // ====================== 配置区 ======================
        const REFRESH_INTERVAL = 2000;      // 防刷新间隔(ms)
        const LOADING_TIMEOUT = 6500;       // Loading最大存活超时时间(ms)
        const STORAGE_KEY = 'lastRefreshTime';
        const LOADING_IDS = ['loading', 'loader', 'ajax-loading', 'page-loading'];
        const LOADING_SELECTOR = '.loading, .loader, .mask, .spinner';
        const TOAST_DURATION = 500;        // 提示框展示时长

        var loadingTimer = null;
        var toastTimer = null;

        // ====================== 原生顶部Toast：白底、橙色文字 ======================
        function nativeToast(text) {
            // 移除上一条toast
            const oldToast = document.getElementById('__prevent_refresh_toast');
            if (oldToast) oldToast.remove();
            clearTimeout(toastTimer);

            // 一次性注入样式
            if (!document.getElementById('__prevent_refresh_toast_style')) {
                const style = document.createElement('style');
                style.id = '__prevent_refresh_toast_style';
                style.textContent = `
                    #__prevent_refresh_toast {
                        position: fixed;
                        left: 50%;
                        top: 20px;
                        transform: translateX(-50%);
                        background-color: #ffffff;
                        color: #ff7800;
                        padding: 9px 22px;
                        border-radius: 8px;
                        font-size: 14px;
                        box-shadow: 0 2px 12px rgba(0,0,0,0.12);
                        z-index: 999999;
                        white-space: nowrap;
                        animation: toastSlideDown 0.24s ease;
                    }
                    @keyframes toastSlideDown {
                        from {
                            opacity: 0;
                            transform: translateX(-50%) translateY(-15px);
                        }
                        to {
                            opacity: 1;
                            transform: translateX(-50%) translateY(0);
                        }
                    }
                    .toast-fade-out {
                        opacity: 0;
                        transform: translateX(-50%) translateY(-15px);
                        transition: all 0.2s ease;
                    }
                `;
                document.head.appendChild(style);
            }

            const toastDom = document.createElement('div');
            toastDom.id = '__prevent_refresh_toast';
            toastDom.innerText = text;
            document.body.appendChild(toastDom);

            // 倒计时关闭，带上滑淡出动画
            toastTimer = setTimeout(() => {
                toastDom.classList.add('toast-fade-out');
                setTimeout(() => toastDom.remove(), 200);
            }, TOAST_DURATION);
        }

        /**
         * 强制隐藏loading遮罩
         */
        function forceHideLoading() {
            try {
                clearTimeout(loadingTimer);
                loadingTimer = null;

                LOADING_IDS.forEach(function (id) {
                    const el = document.getElementById(id);
                    el && (el.style.display = 'none');
                });
                const list = document.querySelectorAll(LOADING_SELECTOR);
                for (let i = 0; i < list.length; i++) {
                    list[i].style.display = 'none';
                }
            } catch (e) {
                console.warn('【防刷新】关闭loading异常', e);
            }
        }

        /**
         * 启动loading超时兜底定时器
         */
        function startLoadingTimeout() {
            clearTimeout(loadingTimer);
            loadingTimer = setTimeout(forceHideLoading, LOADING_TIMEOUT);
        }

        /**
         * 防频繁刷新主逻辑
         */
        function refreshControl() {
            try {
                const now = Date.now();
                const lastTime = parseInt(sessionStorage.getItem(STORAGE_KEY), 10) || 0;

                startLoadingTimeout();

                if (lastTime && now - lastTime < REFRESH_INTERVAL) {
                    forceHideLoading();
                    nativeToast('😜刷新过于频繁，请稍后再试');
                    return;
                }
                sessionStorage.setItem(STORAGE_KEY, now);
            } catch (err) {
                console.error('【防刷新】refreshControl异常：', err);
                forceHideLoading();
            }
        }

        // 绑定页面事件
        document.addEventListener('DOMContentLoaded', refreshControl);
        window.addEventListener('load', forceHideLoading);

        // 页面卸载清理定时器
        window.addEventListener('beforeunload', function () {
            clearTimeout(loadingTimer);
            clearTimeout(toastTimer);
        });

    } catch (globalErr) {
        console.error('【prevent-refresh脚本初始化失败】', globalErr);
    }
})();