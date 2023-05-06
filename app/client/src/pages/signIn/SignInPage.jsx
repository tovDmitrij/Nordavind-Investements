import React, { useContext, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import useFetching from '../../components/hooks/useFetching'
import { AuthContext } from '../../components/context/authContext'
import SignInForm from '../../components/UI/forms/signIn/SignInForm'
import FetchLoader from '../../components/UI/loaders/fetch/FetchLoader'
import ErrorPanel from '../../components/UI/panels/error/ErrorPanel'
import classes from './SignInPage.module.css'


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
    const [SignIn, isLoading, inputError] = useFetching(async (userInfo) => {
        await fetch(`https://localhost:7047/api/Auth/SignIn/email=${userInfo.email}&password=${userInfo.password}`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            }
        }).then(response => {
            if(response.ok){
                response.json().then((data) => {
                    setIsAuth(true)
                    sessionStorage.setItem('token', data.token)   
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
        <div className={`grid place-items-center gap-4 grid-cols-1 grid-rows-1 ${classes.myPage}`}>
            <SignInForm accept={SignIn} error={setError} />
            {isLoading && <FetchLoader /> }
            {inputError && <ErrorPanel error={inputError} /> }
            {responseError && <ErrorPanel error={responseError} /> }
        </div>
    )
}


export default SignInPage