// Write your JavaScript code.

function showHideSecondLanguage(elem)
{
    if (elem.checked === true)
    {
        document.getElementById("secondLanguageForm").style.display = "block";
    }
    else
    {
        document.getElementById("secondLanguageForm").style.display = "none";
    }
}

function showHideSpouseExist(exist)
{
    if (exist.checked === true)
    {
        document.getElementById("spouseExistForm").style.display = "block";
    }
    else 
    {
        document.getElementById("spouseExistForm").style.display = "none";
    }
}