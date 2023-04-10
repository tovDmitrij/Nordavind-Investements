using Microsoft.AspNetCore.Mvc;
using database.context.Repos;
using misc.security;
using Microsoft.Net.Http.Headers;
using api.Misc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventRepos _eventRepos;
        public EventController(IEventRepos db) => _eventRepos = db;
        
        [HttpGet("MainEvents/Get")]
        public IActionResult GetMainEventList()
        {
            var mainEvents = _eventRepos.GetMainEvents();
            if (!mainEvents.Any())
                return StatusCode(404, new { status = "Данные были не найдены" });
            return StatusCode(200, new { status = "СОбытия были найдены", data = mainEvents });
        }

        [HttpGet("FlipEvents/Get")]
        public IActionResult GetFlipEventList()
        {
            var flipEvents = _eventRepos.GetFlipEvents();
            if (!flipEvents.Any())
                return StatusCode(404, new { status = "Данные были не найдены" });
            return StatusCode(200, new { status = "СОбытия были найдены", data = flipEvents });
        }

        [HttpGet("PayEvents/Get")]
        public IActionResult GetPayEventList()
        {
            var events = _eventRepos.GetPayEvents();
            if (!events.Any())
                return StatusCode(404, new { status = "Данные были не найдены" });
            return StatusCode(200, new { status = "СОбытия были найдены", data = events });
        }

        [HttpGet("SellEvents/Get")]
        public IActionResult GetSellEventList()
        {
            var events = _eventRepos.GetSellEvents();
            if (!events.Any())
                return StatusCode(404, new { status = "Данные были не найдены" });
            return StatusCode(200, new { status = "События были найдены", data = events });
        }

        [HttpGet("Account/acc_id={acc_id:int}/MainEvents/Get")]
        public IActionResult GetMainEventList(int acc_id)
        {
            if (!_eventRepos.IsAccountIdExists(acc_id))
                return StatusCode(404, new { status = "Аккаунта не сущетсвует" });
            var events = _eventRepos.GetMainEvents(acc_id);
            if(!events.Any())
                return StatusCode(404, new { status = "Данные были не найдены" });
            return StatusCode(200, new { status = "События были найдены", data = events });
        }

        [HttpGet("Account/acc_id={acc_id:int}/FlipEvents/Get")]
        public IActionResult GetFlipEventList(int acc_id)
        {
            if (!_eventRepos.IsAccountIdExists(acc_id))
                return StatusCode(404, new { status = "Аккаунта не сущетсвует" });
            var events = _eventRepos.GetFlipEvents(acc_id);
            if (!events.Any())
                return StatusCode(404, new { status = "Данные были не найдены" });
            return StatusCode(200, new { status = "События были найдены", data = events });
        }

        [HttpGet("Account/acc_id={acc_id:int}/SellEvents/Get")]
        public IActionResult GetSellEventList(int acc_id)
        {
            if (!_eventRepos.IsAccountIdExists(acc_id))
                return StatusCode(404, new { status = "Аккаунта не сущетсвует" });
            var events = _eventRepos.GetSellEvents(acc_id);
            if (!events.Any())
                return StatusCode(404, new { status = "Данные были не найдены" });
            return StatusCode(200, new { status = "События были найдены", data = events });
        }


        [HttpPost("MainEvents/Add/op_id={op_id:int}&acc_id={acc_id:int}&value={value:decimal}&date={date:datetime}&hold_interest={hold_interest:boolean}&link={link}")]
        public IActionResult AddEvent(int op_id, int acc_id, decimal value, DateTime date, bool hold_interest, string? link)
        {
            if (!_eventRepos.IsAccountIdExists(acc_id))
                return StatusCode(404, new { status = "Аккаунта не существует" });
            if (!_eventRepos.IsOperationExists(op_id))
                return StatusCode(404, new { status = "Операции не существует" });
            _eventRepos.AddMainEvent(op_id,value,date,acc_id,hold_interest,link);
            return StatusCode(200, new { status = "Событие по внесению/выводу средств было успешно добавлено" });
        }

        [HttpPost("FlipEvents/Add/op_id={op_id:int}&acc_from={acc_from:int}&acc_to={acc_to:int}&fund_id{fund_id:int}&value={value:decimal}&date={date:datetime}")]
        public IActionResult AddEvent(int op_id, int acc_from, int acc_to, int fund_id, decimal value, DateTime date)
        {
            if (!_eventRepos.IsAccountIdExists(acc_from))
                return StatusCode(404, new { status = "Аккаунта X не существует" });
            if (!_eventRepos.IsAccountIdExists(acc_to))
                return StatusCode(404, new { status = "Аккаунта Y не существует" });
            if (!_eventRepos.IsOperationExists(op_id))
                return StatusCode(404, new { status = "Операции не существует" });
            if (!_eventRepos.IsFundIdExists(fund_id))
                return StatusCode(404, new { status = "Тип средств не существует" });
            _eventRepos.AddFlipEvent(op_id, value, date, acc_from, acc_to, fund_id);
            
            return StatusCode(200, new { status = "Событие о переносе средств было успешно добавлено" });
        }

        [HttpPost("PayEvents/Add/op_id={op_id:int}&value={value:decimal}&date={date:datetime}&link={link}")]
        public IActionResult AddEvent(int op_id, decimal value, DateTime date, string link)
        {
            if (!_eventRepos.IsOperationExists(op_id))
                return StatusCode(404, new { status = "Операции не существует" });
            _eventRepos.AddPayEvent(op_id, value, date, link);
            return StatusCode(200, new { status = "Событие о переводе зарплаты сотруднику было добавлено" });
        }

        [HttpPost("SellEvents/Add/op_id={op_id:int}&value={value:decimal}&date={date:datetime}&acc_id={acc_id:int}&bot_type={bot_type:int}")]
        public IActionResult AddEvent(int op_id, decimal value, DateTime date, int acc_id, int bot_type)
        {
            if (!_eventRepos.IsAccountIdExists(acc_id))
                return StatusCode(404, new { status = "Аккаунта не существует" });
            if (!_eventRepos.IsOperationExists(op_id))
                return StatusCode(404, new { status = "Операции не существует" });
            if (!_eventRepos.IsBotTypeExists(bot_type))
                return StatusCode(404, new { status = "Тип бота не найден" });
            _eventRepos.AddSellEvent(op_id, value, date, acc_id, bot_type);
            return StatusCode(200, new { status = "Событие о продаже бота было добавлено" });
        }

        [HttpPut("MainEvents/Update/event_id={event_id:int}&acc_id={acc_id:int}&hold_interest={hold_interest:boolean}&link={link}")]
        public IActionResult UpdateMainEvent(int event_id, int acc_id, bool hold_interest, string link)
        {
            if (!_eventRepos.IsAccountIdExists(acc_id))
                return StatusCode(404, new { status = "Аккаунта не существует" });
            if (!_eventRepos.IsEventExists(event_id))
                return StatusCode(404, new { status = "Событие не найдено" });
            _eventRepos.UpdateMainEvent(event_id,acc_id,hold_interest,link);
            return StatusCode(200, new { status = "Событие было обновлено" });
        }

        [HttpPut("FlipEvents/Update/event_id={event_id:int}&acc_from={acc_from:int}&acc_to={acc_to:int}&fund_id={fund_id:int}")]
        public IActionResult UpdateFlipEvent(int event_id, int acc_from, int acc_to, int fund_id)
        {
            if (!_eventRepos.IsEventExists(event_id))
                return StatusCode(404, new { status = "Событие было не найдено" });
            if (!_eventRepos.IsAccountIdExists(acc_from))
                return StatusCode(404, new { status = "Аккаунта X не существует" });
            if (!_eventRepos.IsAccountIdExists(acc_to))
                return StatusCode(404, new { status = "Аккаунта Y не существует" });
            if (!_eventRepos.IsFundIdExists(fund_id))
                return StatusCode(404, new { status = "Тип средств не существует" });
            _eventRepos.UpdateFlipEvent(event_id, acc_from, acc_to, fund_id);
            return StatusCode(200, new { status = "Событие было обновлено" });
        }

        [HttpPut("PayEvents/Update/event_id={event_id:int}&link={link}")]
        public IActionResult UpdatePayEvent(int event_id, string link)
        {
            if (!_eventRepos.IsEventExists(event_id))
                return StatusCode(404, new { status = "Событие не найдено" });
            _eventRepos.UpdatePayEvent(event_id,link);
            return StatusCode(200, new { status = "Собыьте было обновлено" });
        }

        [HttpPut("SellEvents/Update/event_id={event_id:int}&acc_id={acc_id:int}&bot_type={bot_type:int}")]
        public IActionResult UpdateSellEvent(int event_id, int acc_id, int bot_type)
        {
            if (!_eventRepos.IsEventExists(event_id))
                return StatusCode(404, new { status = "Событие не найдено" });
            if (!_eventRepos.IsAccountIdExists(acc_id))
                return StatusCode(404, new { status = "Аккаунта не существует" });
            if (!_eventRepos.IsBotTypeExists(bot_type))
                return StatusCode(404, new { status = "Тип бота не найден" });
            _eventRepos.UpdateSellEvent(event_id, acc_id, bot_type);
            return StatusCode(200, new { status = "Событие было обновлено" });
        }

        [HttpDelete("MainEvents/Delete/event_id={event_id:int}")]
        public IActionResult DeleteMainEvent(int event_id)
        {
            if (!_eventRepos.IsEventExists(event_id))
                return StatusCode(404, new { status = "Событие не найдено" });
            _eventRepos.DeleteMainEvent(event_id);
            return StatusCode(200, new { status = "Событие было удалено" });
        }

        [HttpDelete("FlipEvents/Delete/event_id={event_id:int}")]
        public IActionResult DeleteFlipEvent(int event_id)
        {
            if (!_eventRepos.IsEventExists(event_id))
                return StatusCode(404, new { status = "Событие не найдено" });
            _eventRepos.DeleteFlipEvent(event_id);  
            return StatusCode(200, new { status = "Событие было удалено" });
        }

        [HttpDelete("PayEvents/Delete/event_id={event_id:int}")]
        public IActionResult DeletePayEvent(int event_id)
        {
            if (!_eventRepos.IsEventExists(event_id))
                return StatusCode(404, new { status = "Событие не найдено" });
            _eventRepos.DeletePayEvent(event_id);
            return StatusCode(200, new { status = "Событие было удалено" });
        }

        [HttpDelete("SellEvents/Delete/event_id={event_id:int}")]
        public IActionResult DeleteSellEvent(int event_id)
        {
            if (!_eventRepos.IsEventExists(event_id))
                return StatusCode(404, new { status = "Событие не найдено" });
            _eventRepos.DeleteSellEvent(event_id);
            return StatusCode(200, new { status = "Событие было удалено" });
        }
    }
}
