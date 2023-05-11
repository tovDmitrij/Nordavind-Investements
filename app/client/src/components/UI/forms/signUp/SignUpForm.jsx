import React, {useState} from 'react'
import MyInput from '../../inputs/MyInput'
import MyButton from '../../buttons/MyButton'
import FormLabel from '../../labels/FormLabel'
import styles from './SignUpForm.module.css'


/**
 * Форма регистрации пользователя в системе
 * @param {*} accept - callback-функция для передачи данных
 * @param {*} error - callback-функция для передачи возможной ошибки
 */
const SignUpForm = ({accept, error}) => {
    const[email, setEmail] = useState('')
    const[password, setPassword] = useState('')
    const[repeatedPass, setRepeatedPass] = useState('')

    /**
     * Подтверждение формы регистрации
     */
    const SignUp = (e) => {
        e.preventDefault()

        const emailRegex = /[A-Za-zА-Яа-я0-9]+@[A-Za-z]+.[A-Za-z]+/g
        const emailMatch = email.match(emailRegex)
        if (emailMatch == null){
            error("Почта не валидная")
            return false
        }

        const passRegex = /[\S+]{8,16}/g
        const passMatch = password.match(passRegex)
        const repPassMatch = repeatedPass.match(passRegex)
        if (passMatch == null || repPassMatch == null){
            error("Пароль не валидный")
            return false
        }
        if (password !== repeatedPass){
            error('Пароли не совпадают')
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
                <h1 className={styles.myHeader}>Регистрация</h1>
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

            <div className='grid place-items-center'>
                <MyInput
                    type="password"
                    onChange={e => setRepeatedPass(e.target.value)}
                    placeholder='Повторите пароль'/>
            </div>

            <MyButton 
                onClick={SignUp}
                children={"Подтвердить"}/>
        </form>
    )
}


export default SignUpForm