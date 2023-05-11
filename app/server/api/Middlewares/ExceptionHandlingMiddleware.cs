namespace api.Middlewares
{
    /// <summary>
    /// Миддлвэер-обработчик ошибок
    /// </summary>
    public sealed class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await context.Response.WriteAsJsonAsync(new { statusCode = 500, status = "Произошла непредвиденная ошибка. Повторите позже" });
                //await context.Response.WriteAsJsonAsync(new { statusCode = 500, status = ex.Message });
                /* TODO
                 * Сделать добавление логов в БД
                 */
            }
        }
    }
}