import React from 'react'
import styles from './FormLabel.module.css'


/**
 * Подсказка к инпуту формы заполнения
 * @param {*} title - текст подсказки
 */
const FormLabel = ({ title, ...props }) => {
    return (
        <label className={styles.myLbl} {...props}>{title}</label>
    )
}


export default FormLabel