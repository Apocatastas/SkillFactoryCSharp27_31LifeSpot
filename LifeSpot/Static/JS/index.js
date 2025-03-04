let session = new Map();
session.set("userAgent", window.navigator.userAgent)
session.set("age", prompt("Please enter your age:"))
if (session.get("age") >= 18) {
    let startDate = new Date().toLocaleString();

    alert("Welcome on Lifespot! " + '\n' + "Time of visit: " + startDate);
    session.set("startDate", startDate)
}
else {
    alert("Viewer discretion is advised for people under 18. Redirecting...");
    window.location.href = "http://www.google.com"
    a = true + 20 + "name"
}

for (let result of session) {
    console.log(result)
}