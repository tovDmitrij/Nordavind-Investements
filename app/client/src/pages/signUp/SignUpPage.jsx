import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { useFetching } from '../../components/hooks/useFetching'
import { SignUpForm } from '../../components/UI/forms/signUp/SignUpForm'
import { Loader } from '../../components/UI/loader/Loader'
import { ErrorPanel } from '../../components/UI/error/ErrorPanel'
import classes from './SignUpPage.module.css'
import APIService from '../../API/APIService'


/**
 * Страница для регистрации пользователя в системе
 */
export const SignUpPage = () => {
    const navigate = useNavigate();
    const [responseError, setError] = useState('')

    /**
     * Регистрация пользователя в системе 
     * @param {*} userInfo - почта и пароль пользователя
     */
    const [SignUp, isLoading, error] = useFetching(async (userInfo) => {
        APIService.SignUpSubmit(userInfo).then(response => {
            if (response.ok){
                navigate("/signIn")
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
            <SignUpForm accept={SignUp} error={setError} />
            
            {error && <ErrorPanel error={error} /> }
            {responseError && <ErrorPanel error={responseError} /> }
        </div>
    )
}