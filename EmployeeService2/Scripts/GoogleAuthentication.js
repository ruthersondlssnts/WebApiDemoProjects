/// <reference path="jquery-3.4.1.min.js" />
//function retrieves the access token from the URL
function getAccessToken() {


    var signupExternalUser = function (token) {
        //function registers the user with our application
        $.ajax({
            url: '/api/Account/RegisterExternal',
            method: 'POST',
            headers: {
                'content-type': 'application/JSON',
                'Authorization': 'Bearer ' + token
            },
            success: function () {
                window.location.href = "/api/Account/ExternalLogin?provider=Google&response_type=token&client_id=self&redirect_uri=https%3A%2F%2Flocalhost%3A44340%2FHtml%2FLogin.html&state=hPiXIKNPFzSJPqYgXzKRdKocBkwCJZNDT2_qmAjBDlg1";
            }
        });
    };

    
    var isUserRegistered = function (token) { 
        //function checks if the user authenticated by Google is registered with our application
        $.ajax({
            url: '/api/Account/UserInfo',
            method: 'GET',
            headers: {
                'content-type': 'application/JSON',
                'Authorization': 'Bearer ' + token
            },
            success: function(response) {
                
                if (response.HasRegistered) {
                    localStorage.setItem('accessToken', token);
                    localStorage.setItem('userName', response.Email);
                    window.location.href = "Data.html";
                } else {
                    signupExternalUser(token);
                }
            }
        });
    };
    if (location.hash) {
        if (location.hash.split('access_token=')) {
            var accessToken = location.hash.split('access_token=')[1].split('&')[0];
            if (accessToken) {
                isUserRegistered(accessToken);
            }
        }
    }
}