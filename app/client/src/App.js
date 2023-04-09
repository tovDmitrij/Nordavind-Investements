import React, { useEffect } from "react"
import { useState } from "react"
import { BrowserRouter } from "react-router-dom"
import { AuthContext } from "./components/context/authContext"
import { AppRouter } from './components/AppRouter'
import { HeaderNavbar } from "./components/UI/navbar/HeaderNavbar"


function App() {
    const [isAuth, setIsAuth] = useState(false)
    const [isLoading, setLoading] = useState(true)

    useEffect(() => {
        if (sessionStorage.getItem('token')){
            setIsAuth(true)
        }
        setLoading(false)
    }, [])

    return (
        <AuthContext.Provider value={{isAuth, setIsAuth, isLoading}}>
            <BrowserRouter>
            
                <HeaderNavbar />

                <div className="grid place-items-center">
                    <AppRouter />
                </div>

            </BrowserRouter>
        </AuthContext.Provider>
    )
}


export default App;