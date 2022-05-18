
$(document).ready(function () {
    var arr = [];
    $('input[type=checkbox]').on('change', function () {
        var body = document.body;
        var header = document.getElementById("nav");
        var search = document.getElementById("elastic");
        var card = document.querySelectorAll("#card");
        var elastic = document.querySelectorAll("#elastic-list li");
        var table = document.getElementById("table")
        var convertInput = document.querySelectorAll(".form-control");
        var currencyList = document.querySelectorAll(".top_currencies_list");
        var currency = document.querySelectorAll(".currency");
        var convertSelect = document.querySelectorAll(".form-select");

        if ($(this).is(':checked')) {
            sessionStorage.setItem('darkmode', 'true');
            body.classList.add("dark-mode");
            header.classList.add("dark-mode");
            search.classList.add("dark-mode");
            if (convertInput) {
                convertInput.forEach((el) => {
                    el.classList.add("dark-mode");
                })
                convertSelect.forEach((el) => {
                    el.classList.add("dark-mode");
                })
            }
            if (currency) {
                currency.forEach((el) => {
                    el.classList.add("dark-mode");
                })

            }
            if (currencyList) {
                currencyList.forEach((el) => {
                    el.classList.add("dark-mode");
                })
               
            }

            if (table) {
                table.classList.add("dark-mode");
            }

            elastic.forEach((el) => {
                el.classList.add("dark-mode");
            })
            card.forEach((el) => {
                el.classList.add("dark-mode");
            });

        } else {
            document.documentElement.style.display = 'none';
            document.head.insertAdjacentHTML(
                'beforeend',
                '<link rel="stylesheet" href="/css/site.css" onload="document.documentElement.style.display = \'\'">',
            );
            sessionStorage.setItem('darkmode', 'false');
            body.classList.remove("dark-mode");
            header.classList.remove("dark-mode");
            search.classList.remove("dark-mode");
            if (currency) {
                currency.forEach((el) => {
                    el.classList.remove("dark-mode");
                })

            }
            if (currencyList) {
                currencyList.forEach((el) => {
                    el.classList.remove("dark-mode");
                })

            }
            if (convertInput) {
                convertInput.forEach((el) => {
                    el.classList.remove("dark-mode");
                })
                convertSelect.forEach((el) => {
                    el.classList.remove("dark-mode");
                })
            }
            if (table) {
                table.classList.remove("dark-mode");
            }

            elastic.forEach((el) => {
                el.classList.remove("dark-mode");
            })
            card.forEach((el) => {
                el.classList.remove("dark-mode");
            });
        }
    });

});
addEventListener('load', Check());
function Check() {
  
    var check = sessionStorage.getItem("darkmode");
    if (check == "true") {
        document.getElementById("flexSwitchCheckDefault").checked = true;
    }
    
}

function livesearch() {
    var i = 0;
    let val = document.querySelector('.elastic-box').value.trim();
    let elasticItems = document.querySelectorAll('.elastic li');
    if (val != '') {
        if (/[a-zA-Z]/.test(val)) {
            document.querySelector('.elastic-box').classList.add('search_active')
            document.querySelector('.elastic-box').classList.remove('input_search')
            elasticItems.forEach(function (elem) {

                if (elem.getAttribute('title').search(RegExp(val, "gi")) == -1) {
                    elem.classList.add('hide');
                    if (i == 0) {
                        document.querySelector('.error').classList.remove('hide')
                    } else {
                        document.querySelector('.elastic').classList.remove('hide')
                        document.querySelector('.error').classList.add('hide')
                    }
                } else {
                    i++;
                    elem.classList.remove('hide');
                    if (i == 0) {
                        document.querySelector('.elastic').classList.add('hide')
                    } else {
                        document.querySelector('.elastic').classList.remove('hide')
                    }
                }
            });
        } else {

            document.querySelector('.elastic').classList.remove('hide')
            document.querySelector('.elastic-box').classList.add('search_active')
            document.querySelector('.elastic-box').classList.remove('input_search')
            document.querySelector('.error').classList.remove('hide')

        }
    } else {
        elasticItems.forEach(function (elem) {
            elem.classList.add('hide');
            document.querySelector('.elastic').classList.add('hide')
            document.querySelector('.elastic-box').classList.remove('search_active')
            document.querySelector('.elastic-box').classList.add('input_search')

        });
    }
}

function CloseSearch() {

    let elasticItems = document.querySelectorAll('.elastic li');
    document.querySelector('.elastic-box').value = "";
    elasticItems.forEach(function (elem) {
        elem.classList.add('hide');
        document.querySelector('.elastic').classList.add('hide')
        document.querySelector('.elastic-box').classList.remove('search_active')
        document.querySelector('.elastic-box').classList.add('input_search')

    });
}

