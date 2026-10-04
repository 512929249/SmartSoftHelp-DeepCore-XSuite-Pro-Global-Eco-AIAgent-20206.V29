var builder = WebApplication.CreateBuilder(args);
// ===== 日志记录配置 =====
builder.Logging.ClearProviders();   // 清除默认日志提供程序
builder.Logging.AddConsole();       // 添加控制台日志提供程序，输出到终端‌
// 注册控制器服务，支持 MVC 模式的 API 端点‌
builder.Services.AddControllers();
// ===== 跨域策略配置 =====
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()    // 允许所有来源
                   .AllowAnyHeader()    // 允许所有请求头
                   .AllowAnyMethod();   // 允许所有 HTTP 方法
        });
});
// 启用 API 端点元数据生成
builder.Services.AddEndpointsApiExplorer();
// 集成 Swagger 文档生成功能‌
builder.Services.AddSwaggerGen();
var app = builder.Build();
// 开发环境下启用 Swagger 文档界面‌
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   // 生成 OpenAPI 规范文档
    app.UseSwaggerUI(); // 提供交互式 API 文档界面
}
// 应用跨域策略（需在 UseAuthorization 前调用）‌
app.UseCors("AllowAllOrigins");
// 启用授权中间件（需配合 [Authorize] 特性使用）‌
app.UseAuthorization();
// 映射控制器路由‌
app.MapControllers();
app.Run();