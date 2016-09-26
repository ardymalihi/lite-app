// Write your Javascript code.
function moduleNavbarMouseOver(moduleId)
{
    var section = document.getElementById("module-container-" + moduleId);
    section.style.backgroundColor = "GhostWhite";
}

function moduleNavbarMouseOut(moduleId) {
    var section = document.getElementById("module-container-" + moduleId);
    section.style.backgroundColor = "white";
}

function removeModule(moduleId)
{
    var result = confirm("Are you sure?");
    if (result)
    {
        var section = document.getElementById("module-container-" + moduleId);
        if (section)
        {
            ajaxCall("DELETE", "/Module/Remove/" + moduleId, null, null,
            function (response) {
                section.parentElement.removeChild(section);
            },
            function (error) {
                console.log(error);
            }, true);
            
        }
    }
}

function ajaxCall(httpType, url, obj, xhrHeaders, successHandler, errorHandler, isAsync) {
    try {
        var xhr = new XMLHttpRequest();
        //xhr.withCredentials = true;
        xhr.open(httpType, url, isAsync || true);
        xhr.setRequestHeader("Accept", "application/json");
        xhr.setRequestHeader("Content-Type", "application/json");
        xhr.setRequestHeader("Access-Control-Allow-Origin", "true");
        //xhr.setRequestHeader("Access-Control-Allow-Credentials", "true");
        Object.keys(xhrHeaders || {}).forEach(function (key, idx) {
            xhr.setRequestHeader(key, xhrHeaders[key]);
        });
        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4 && xhr.status === 200) {
                if (successHandler) {
                    successHandler(xhr.response);
                    xhr.onreadystatechange = undefined;
                }
            }
            else {
                return;
            }
        };
        xhr.send(obj);
    } catch (error) {
        if (errorHandler) {
            errorHandler(error);
        }
    }
};
