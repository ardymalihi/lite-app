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
            section.parentElement.removeChild(section);
        }
    }
}
