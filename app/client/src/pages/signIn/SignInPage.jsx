import React, { useContext, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { useFetching } from '../../components/hooks/useFetching'
import { AuthContext } from '../../components/context/authContext'
import { Loader } from '../../components/UI/loader/Loader'
import { ErrorPanel } from '../../components/UI/error/ErrorPanel'
import APIService from '../../API/APIService'
import styles from './SignInPage.module.css'
import SignInForm from '../../components/UI/forms/signIn/SignInForm'


/**
 * Страница для авторизации пользователя в системе
 */
const SignInPage = () => {
    const navigate = useNavigate();
    const {isAuth, setIsAuth} = useContext(AuthContext)
    const [responseError, setError] = useState('')

    /**
     * Авторизация пользователя в системе
     * @param {*} userInfo - почта и пароль пользователя
     */
    const [SignIn, isLoading, error] = useFetching(async (userInfo) => {
        APIService.SignInSubmit(userInfo).then(response => {
            if (response.ok){
                response.json().then((data) => {
                    setIsAuth(true)
                    localStorage.setItem('token', data.token) 
                    navigate("/events")             
                })
            }
            else{
                response.json().then((data) => {
                    setError(data.status)
                })
            }
        }).catch(err => { setError(err.status) })
    })

    return(
        <div className={`grid place-self-center place-items-center gap-4 grid-cols-1 grid-rows-1 ${styles.myPage}`}>
            <SignInForm accept={SignIn} error={setError} />

            {isLoading && <Loader />}
            {error && <ErrorPanel error={error} />}
            {responseError && <ErrorPanel error={responseError} />}
        </div>
    )
}


export default SignInPage