import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import useFetching from '../../components/hooks/useFetching'
import SignUpForm from '../../components/UI/forms/signUp/SignUpForm'
import FetchLoader from '../../components/UI/loaders/fetch/FetchLoader'
import ErrorPanel from '../../components/UI/panels/error/ErrorPanel'
import classes from './SignUpPage.module.css'


/**
 * Страница для регистрации пользователя в системе
 */
const SignUpPage = () => {
    const navigate = useNavigate();
    const [responseError, setError] = useState('')

    /**
     * Регистрация пользователя в системе 
     * @param {*} userInfo - почта и пароль пользователя
     */
    const [SignUp, isLoading, error] = useFetching(async (userInfo) => {
        await fetch(`https://localhost:7047/api/Auth/SignUp/email=${userInfo.email}&password=${userInfo.password}`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            }
        }).then(response => {
            if(response.ok){
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
            {isLoading && 
                <FetchLoader />
            }
            {error && 
                <ErrorPanel error={error} />
            }
            {responseError && 
                <ErrorPanel error={responseError} />
            }
        </div>
    )
}


export default SignUpPage