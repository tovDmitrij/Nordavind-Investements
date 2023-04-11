import React from 'react'


const MySelect = ({items, callback}) => {
    return (
        <select onChange={(e) => callback(e.target.value)}>
            {items.map((i => {
                <option key={i.id} value={i.id}>{i.title}</option>
            }))}
        </select>
    )
}


export default MySelect