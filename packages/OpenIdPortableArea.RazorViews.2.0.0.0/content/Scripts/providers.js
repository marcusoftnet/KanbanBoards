function OpenIdHandler(site, autopost) {
    switch (site) {
        case "google":
            HandleProvider("https://www.google.com/accounts/o8/id", autopost);
            break;
        case "yahoo":
            HandleProvider("http://yahoo.com/", autopost);
            break;
        case "myOpenId":
            HandleProvider("<Your Account>.myopenid.com", autopost);
            break;
        case "AOL":
            HandleProvider("http://openid.aol.com/<Your Screen Name>", autopost);
            break;
    }
}

function HandleProvider(url, autopost) {
    var textBox = document.getElementById('openIdUrl');
    textBox.value = url;
    textBox.focus();
    if (autopost)
        document.getElementById('loginButton').click();
}