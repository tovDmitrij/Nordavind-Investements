import React, {useState} from 'react'
import MyInput from '../../inputs/MyInput'
import MyButton from '../../buttons/MyButton'
import FormLabel from '../../labels/FormLabel'
import styles from './SignInForm.module.css'


/**
 * Форма авторизации пользователя в системе
 * @param {*} accept - callback-функция для передачи данных
 * @param {*} error - callback-функция для передачи возможной ошибки
 */
const SignInForm = ({accept, error}) => {
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
            return false
        }

        const passRegex = /[\S+]{8,16}/g
        const passMatch = password.match(passRegex)
        if (passMatch == null){
            error("Пароль не валидный")
            return false
        }

        const userInfo = {
            email: email,
            password: password
        }
        accept(userInfo)
    }

    return(
        <form className={`grid grid-cols-1 ${styles.myForm}`}>
            <div className='grid place-items-center'>
                <h1 className={styles.myHeader}>Авторизация</h1>
                <hr/>
            </div>

            <FormLabel title={'Почта'}/>
            <div className='grid place-items-center'>
                <MyInput 
                    type="email"
                    onChange={e => setEmail(e.target.value)}
                    placeholder='Введите логин'/>
            </div>
            
            <FormLabel title={'Пароль'}/>
            <div className='grid place-items-center'>
                <MyInput
                    type="password"
                    onChange={e => setPassword(e.target.value)}
                    placeholder='Введите пароль'/>
            </div>
                
            <MyButton 
                onClick={SignIn}
                children={"Подтвердить"}/>
        </form>
    )
}


export default SignInForm