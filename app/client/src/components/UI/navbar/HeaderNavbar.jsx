import React, { useContext } from 'react'
import { Link } from 'react-router-dom'
import { AuthContext } from "../../context/authContext"
import MyButton from '../button/MyButton'
import classes from './HeaderNavbar.module.css'


/**
 * Навигационная панель веб-приложения
 */
export const HeaderNavbar = () => {
    const {isAuth, setIsAuth} = useContext(AuthContext)

    /**
     * Выйти из аккаунта
     */
    const LogOut = () => {
        setIsAuth(false)
        sessionStorage.removeItem('id')
        sessionStorage.removeItem('token')
    }

    return (
        isAuth ? 
        (
        <div className={classes.navbar}>
            <div className={classes.navbar__links}>
                <Link className={classes.links} to="/events">События</Link>
                <Link className={classes.links} to="/directory">Справочник</Link>
                {/*При добавлении страниц сюда добавлять новые ссылки!*/}
                <MyButton 
                    className={classes.links} 
                    onClick={LogOut}
                    children={"Выйти"}/>
            </div>
        </div>
        )
        :
        (
        <div className={classes.navbar}>
            <div className={classes.navbar__links}>
                <Link className={classes.links} to="/signIn">Автор.</Link>
                <Link className={classes.links} to="/signUp">Регистр.</Link>
            </div>
        </div>
        )
    )
}