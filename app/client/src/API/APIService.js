/**
 * Адрес APIшки
 */
const url = 'https://localhost:7047/api/'


/**
 * Сервис, предоставляющий возможность отправлять запросы к API
 */
export default class APIService {
    /**
     * Подтверждение авторизации пользователя в системе
     * @param {*} user - почта и пароль
     */
    static async SignInSubmit(user) {
        return await fetch(`${url}Auth/SignIn/email=${user.email}&password=${user.password}`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            }
        })
    }

    /**
     * Подтверждение регистрации пользователя в системе
     * @param {*} user - почта, пароль и ФИО
     */
    static async SignUpSubmit(user) {
        return await fetch(`${url}Auth/SignUp/email=${user.email}&password=${user.password}`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            }
        })
    }

    /**
     * Получить список курсов валют
     */
    static async GetCurrenciesList() {
        return await fetch(`${url}Directory/Сurrencies/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem('token')
            }
        })
    }
    /**
     * Получить список типов счётов
     */
    static async GetAccountTypesList() {
        return await fetch(`${url}Directory/AccountTypes/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem('token')
            }
        })
    }
    /**
     * Получить список типов ботов
     */
    static async GetBotTypesList() {
        return await fetch(`${url}Directory/BotTypes/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem('token')
            }
        })
    }
    /**
     * Получить список распределения заработанного
     */
    static async GetConditionsList() {
        return await fetch(`${url}Directory/Conditions/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem('token')
            }
        })
    }
    /**
     * Получить список ввода/вывода
     */
    static async GetMainEventsList() {
        return await fetch(`${url}Event/MainEvents/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem('token')
            }
        })
    }
    /**
     * Получить список переводов
     */
    static async GetFlipEventsList() {
        return await fetch(`${url}Event/FlipEvents/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem('token')
            }
        })
    }
    /**
     * Получить список оплат
     */
    static async GetPayEventsList() {
        return await fetch(`${url}Event/PayEvents/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem('token')
            }
        })
    }
    /**
     * Получить список продаж
     */
    static async GetSellEventsList() {
        return await fetch(`${url}Event/SellEvents/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem('token')
            }
        })
    }
 

    /**... */
}