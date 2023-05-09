import React, { useContext } from 'react'
import { Link } from 'react-router-dom'
import { AuthContext } from "../../../context/authContext"
import MyButton from '../../buttons/main/MyButton'
import classes from './HeaderNavbar.module.css'
import { privateRoutes, publicRoutes } from '../../../../router/routes'


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
        sessionStorage.removeItem('token')
    }

    return (
        isAuth ? 
        (
        <div className={classes.navbar}>
            <div className={classes.navbar__links}>
                {privateRoutes.map((route) => (
                    <Link key={route.path} className={classes.links} to={route.path}>{route.title}</Link>
                ))}
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
                {publicRoutes.map((route) => (
                    <Link key={route.path} className={classes.links} to={route.path}>{route.title}</Link>
                ))}
            </div>
        </div>
        )
    )
}


export default HeaderNavbar