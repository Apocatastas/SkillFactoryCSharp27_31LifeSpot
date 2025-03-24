let session = {
    'startDate': new Date().toLocaleString(),
    'userAgent': window.navigator.userAgent,
    'userAge': prompt("Пожалуйста, введите ваш возраст?")
}

let sessionLog = function () {
    console.log('Начало сессии: ' + session.startDate)
    console.log('Данные клиента: ' + session.userAgent)
    console.log('Возраст пользователя: : ' + session.userAge)
}

function handleSession() {
    session.set("startDate", new Date().toLocaleString())
    session.set("userAgent", window.navigator.userAgent)
}


function checkAge() {
    if (session.userAge >= 18) {
        alert("Приветствуем на LifeSpot! " + '\n' + "Текущее время: " + new Date().toLocaleString());
    }
    else {
        alert("Наши трансляции не предназначены для лиц моложе 18 лет. Вы будете перенаправлены");
        window.location.href = "http://www.google.com"
    }
}

setTimeout(() =>
    alert("Нравится LifeSpot? " + '\n' + "Подпишитесь на наш Instagram @lifespot999!"),
    30000);