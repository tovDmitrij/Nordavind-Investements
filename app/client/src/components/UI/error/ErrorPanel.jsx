import React from 'react'
import classes from './ErrorPanel.module.css'


/**
 * Плашка, отображающая текст ошибки
 * @param {*} error - текст ошибки
 */
export const ErrorPanel = ({error}) => {
    return (
        <div className={`grid place-items-center grid-cols-1 grid-rows-1 ${classes.main}`}>
            <h1 className={classes.header}><i className="fa-sharp fa-solid fa-circle-exclamation"></i> ОШИБКА</h1>
            <p className={classes.body}>{error}</p>
        </div>
    )
}