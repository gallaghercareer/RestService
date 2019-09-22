function getAllHeroes() {
    $.ajax({
        url: "Services/Service1.svc/getAllHeroes",
        type: "GET",
        dataType: "json",
        success: function (result) {
            console.log(result);
            //heroes is a global variable defined in app.js
            heroes = result;
            drawHeroTable(result);
        }
        }

        );
}

function addHero() {
    var newHero = {
        "FirstName": $("#addFirstname").val(),
        "LastName": $("#addLastname").val(),
        "HeroName": $("#addHeroname").val(),
        "PlaceOfBirth": $("#addPlaceOfBirth").val(),
        "Combat": $("#addCombatPoints").val(),
    };

    $.ajax({
        url: "Services/Service1.svc/addHero",
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(newHero),
        success: function () {
            showOverview();
        }
    })
}

function putHero() {
    updateHero.FirstName = $("#updateFirstname").val();
    updateHero.LastName = $("#updateLastname").val();
    updateHero.HeroName = $("#updateHeroname").val();
    updateHero.PlaceOfBirth = $("#updatePlaceOfBirth").val();
    updateHero.Combat = $("#updateCombatPoints").val();


    $.ajax({
        url: "Services/Service1.svc/UpdateHero/" + updateHero.Id,
        type: "PUT",
        datatype: "json",
        contentType: "application/json",
        data: JSON.stringify(updateHero),
        success: function () {
            showOverview();
        }

    });
}

function deleteHero(heroId) {
    $.ajax({
        url: "Services/Service1.svc/DeleteHero/" + heroId,
        type: "DELETE",
        dataType: "json",
        success: function (result) {
            console.log(result);
            getAllHeroes();
        }
    }

    );
}