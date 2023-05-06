import React from 'react'
import classes from './MyInput.module.css'


const MyIsnput = React.forwardRef((props, ref) => {
    return (
        <input ref={ref} className={classes.myInput} {...props} />
    )
})


export default MyIsnput