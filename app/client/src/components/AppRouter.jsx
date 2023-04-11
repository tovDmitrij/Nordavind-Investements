import React, { useContext } from 'react'
import { Route, Routes, Navigate } from "react-router-dom"
import FetchLoader from './UI/loaders/fetch/FetchLoader'
import { AuthContext } from './context/authContext'
import { publicRoutes, privateRoutes } from '../router/routes'


const AppRouter = () => {
    const {isAuth, setIsAuth, isLoading} = useContext(AuthContext)

    if (isLoading) { return <FetchLoader /> }

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