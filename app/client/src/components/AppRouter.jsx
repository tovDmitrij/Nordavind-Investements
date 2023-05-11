import React, { useContext } from 'react'
import { Route, Routes, Navigate } from "react-router-dom"
import Loader from './UI/loaders/Loader'
import { publicRoutes, privateRoutes } from '../router/routes'
import AuthContext from './context/authContext'


/**
 * Маршрутизатор приложения
 */
const AppRouter = () => {
    const {isAuth, setIsAuth, isLoading} = useContext(AuthContext)

    if (isLoading) {
        return <Loader />
    }

    return (
        isAuth ?
        (<Routes>
            {privateRoutes.map(route =>
                <Route key={route.path} path={route.path} element={<route.element />} />
            )}
            <Route path='/*' element={<Navigate to='events' replace />} />
        </Routes>)
        :
        (<Routes>
            {publicRoutes.map(route =>
                <Route key={route.path} path={route.path} element={<route.element />} />
            )}
            <Route path='/*' element={<Navigate to='signIn' replace />} />
        </Routes>)
    )
}


export default AppRouter