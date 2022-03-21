import React from "react";

class SubscribeBtn extends React.Component {
    constructor(props) {
        super(props);
        this.state = { isSubscribedOn: true };
    }

    handleClick = () => {
        this.setState(prevState => ({
            isSubscribedOn: !prevState.isSubscribedOn
            //реалізувати реквест з делегатами дя підписки
            // чи відписки від курсу
        }));
    }
    render() {
        return (
            // в onClick={(e) => 
            // this.handleClick(***аргумент посилання на наш курс***, e)}
            // також додати провірку на аутентифікацію користувача, 
            // якщо він не залогынений, 
            // дати компонент логін/реєстрацію, або повідомлення щоб залогінився
            <button id="Button-Subscribe" onClick={(e) => this.handleClick(e)}>
                {this.state.isSubscribedOn ? 'Unsubscribe' : 'Subscribe'}
            </button>
        )
    }
}
export default SubscribeBtn;