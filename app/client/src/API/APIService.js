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

    /**... */
}