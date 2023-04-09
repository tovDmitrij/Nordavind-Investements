import React, {useState} from 'react'
import MyInput from '../../input/MyInput'
import MyButton from '../../button/MyButton'
import classes from './SignInForm.module.css'


/**
 * Форма авторизации пользователя в системе
 * @param {*} accept - callback-функция для передачи данных
 */
export const SignInForm = ({accept}) => {
    const[email, setEmail] = useState('')
    const[password, setPassword] = useState('')

    /**
     * Подтверждение формы авторизации
     */
    const SignIn = (e) => {
        e.preventDefault()

        const emailRegex = /[A-Za-zА-Яа-я0-9]+@[A-Za-z]+.[A-Za-z]+/g
        const emailMatch = email.match(emailRegex)
        if (emailMatch == null){
            error("Почта не валидная")
        }

        const passRegex = /[\S+]{8,16}/g
        const passMatch = password.match(passRegex)
        if (passMatch == null){
            error("Пароль не валидный")
        }

        const userInfo = {
            email: email,
            password: password
        }
        accept(userInfo)
    }

    return(
        <form className={`grid place-items-center gap-4 grid-cols-1 grid-rows-4 ${classes.myForm}`}>
            <h1 className={classes.myHeader}>Авторизация</h1>
            <MyInput 
                type="email"
                onChange={e => setEmail(e.target.value)}
                placeholder='Введите логин'/>
            <MyInput
                type="password"
                onChange={e => setPassword(e.target.value)}
                placeholder='Введите пароль'/>
            <MyButton 
                onClick={SignIn}
                children={"Подтвердить"}/>
        </form>
    )
}