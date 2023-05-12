import React, { useContext } from 'react'
import { Link } from 'react-router-dom'
import AuthContext from "../../context/authContext"
import MyButton from '../buttons/MyButton'
import styles from './HeaderNavbar.module.css'


/**
 * Навигационная панель веб-приложения
 */
const HeaderNavbar = () => {
    const {isAuth, setIsAuth} = useContext(AuthContext)

    /**
     * Выйти из аккаунта
     */
    const LogOut = () => {
        setIsAuth(false)
        localStorage.removeItem('token')
    }

    return (
        isAuth ? 
        (
        <div className={`'grid grid-row-1 grid-cols-2 ${styles.navbar}`}>
            <img className={styles.navbar__logo} src='/images/logo.webp' />
            <div className={styles.navbar__links}>
                <MyButton>
                    <Link to="/events">События</Link>
                </MyButton>
                <MyButton>
                    <Link to="/directory">Справочник</Link>
                </MyButton>
                <MyButton 
                    onClick={LogOut}
                    children={"Выйти"}/>
            </div>
        </div>
        )
        :
        (
        <div className={`'grid grid-row-1 grid-cols-2 ${styles.navbar}`}>
            <img className={styles.navbar__logo} src='/images/logo.webp' />
            <div className={styles.navbar__links}>
                <MyButton>
                    <Link to="/signIn">Войти</Link>
                </MyButton>
                <MyButton>
                    <Link to="/signUp">Регистрация</Link>
                </MyButton>
            </div>
        </div>
        )
    )
}


export default HeaderNavbar