import React from 'react'

let Notification = (props) =>{
    return (
        <div id={props.notificationId} className="notification"><span>{props.message}</span></div>
    )
}

export default Notification