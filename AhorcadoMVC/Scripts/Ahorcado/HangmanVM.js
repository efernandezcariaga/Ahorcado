﻿/// <reference path="../knockout-3.4.0.debug.js" />
/// <reference path="../jquery-3.1.1.js" />
/// <reference path="../knockout.mapping-latest.debug.js" />

HangmanVM = function (data) {

    var self = this;

    ko.mapping.fromJS(data, {}, self);
    self.enableWordToGuess = ko.observable(true);


    self.insertWordToGuess = function () {
        $.post(
            {
                url: "/Ahorcado/InsertWordToGuess",
                data: ko.mapping.toJS(self),
                success: function (response) {
                    //debugger;
                    ko.mapping.fromJS(response, {}, self);

                    // No los mapea
                    self.ChancesLeft(response.chancesLeft);
                    self.Message(response.message);
                    self.WrongLetters(response.wrongLetters);


                    if (self.Message () !== "Palabra secreta invalida") {
                        self.enableWordToGuess(false);
                    }
                    else {
                        self.NotifyMessage(response.message);
                    }
                    
                },
                error: function () {
                    self.NotifyMessage("Ha ocurrido un error inesperado");

                }
            });
    }
    self.tryLetter = function () {

        $.post(
            {
                url: "/Ahorcado/TryLetter",
                data: ko.mapping.toJS(self),
                success: function (response) {
                    debugger;

                    ko.mapping.fromJS(response, {}, self);
                    // No los mapea
                    self.ChancesLeft(response.chancesLeft);
                    self.Message(response.message);
                    self.WrongLetters(response.wrongLetters);
                    self.GuessingWord(response.guessingWord);
                    self.Win(response.win)


                    if (self.Message() !== "Acierto") {
                        self.drawHangman();
                        self.NotifyMessage(self.Message());
                    }
                    else if (self.Message() == "Acierto") {
                        self.NotifyMessage(self.Message());
                    }


                    if(self.Win())
                    {
                        self.Notify("win");
                    }

                    else if(self.ChancesLeft() == 0)
                    {
                        self.Notify("loss");
                    }
                },
                error: function () {
                    self.NotifyMessage("Error inesperado");

                }
            })
    }

    self.tryWord = function () {
        $.post(
            {
                url: "/Ahorcado/TryWord",
                data: ko.mapping.toJS(self),
                success: function (response) {

                    ko.mapping.fromJS(response, {}, self);

                    // No los mapea
                    self.ChancesLeft(response.chancesLeft);
                    self.Message(response.message);
                    self.WrongLetters(response.wrongLetters);
                    self.GuessingWord(response.guessingWord);
                    self.Win(response.win);

                    if (self.Message() !== "Palabra correcta") {
                        self.drawHangman();
                        self.NotifyMessage(self.Message());
                    }
                    if (self.Win()) {
                        self.Notify("win");
                    }
                    else if (self.ChancesLeft() == 0) {
                        self.Notify("loss");
                    }
                },
                error: function () {

                }
            })
    }

    self.Notify = function (type) {
        var opts = {
            cornerclass: "",
            width: "70%",
            buttons: {
                closer: true,
                sticker: false
            }
        };
        switch (type) {
            case 'loss':
                opts.title = "Oh!!";
                opts.text = "Has Perdido!! Más suerte la próxima!";
                opts.type = "error";
                break;
            case 'win':
                opts.title = "Felicitaciones!!!";
                opts.text = "Has ganado!!";
                opts.type = "success";
                break;
        }
        PNotify.removeAll();
        new PNotify(opts);
    }

    self.NotifyMessage = function (message) {
        var opts = {
            cornerclass: "",
            width: "30%",
            buttons: {
                closer: true,
                sticker: false
            },
            dir1: 'right',
            dir2: 'up',
            firstpos1: 25,
            firstpos2: 25,
            push: 'top',
            maxStrategy: 'close'
        };
        opts.text = message;
        PNotify.removeAll();
        new PNotify(opts);
    }

    self.resetGame = function()
    {
        self.enableWordToGuess(true);
        self.WordToGuess("");
        self.LetterTyped("");
        self.GuessingWord("");
        self.ChancesLeft(null);
        self.WrongLetters("");
        self.Win(false);
        var canvas = $("#AhorcadoCanvas")[0];
        canvas.width = canvas.width;
    }

    self.drawHangman = function () {
        var canvas = $("#AhorcadoCanvas")[0];
        var c = canvas.getContext('2d');
        // reset the canvas and set basic styles
        canvas.width = canvas.width;
        c.lineWidth = 10;
        c.strokeStyle = 'green';
        c.font = 'bold 24px Optimer, Arial, Helvetica, sans-serif';
        c.fillStyle = 'red';
        // draw the ground
        drawLine(c, [20, 190], [180, 190]);
        // start building the gallows if there's been a bad guess
        if (self.ChancesLeft() < 7) {
            // create the upright
            c.strokeStyle = '#A52A2A';
            drawLine(c, [30, 185], [30, 10]);
            // create the arm of the gallows
            c.lineTo(150, 10);
            c.stroke();
            if (self.ChancesLeft() < 6) {
                c.strokeStyle = 'black';
                c.lineWidth = 3;
                // draw rope
                drawLine(c, [145, 15], [145, 30]);
                // draw head
                c.beginPath();
                c.moveTo(160, 45);
                c.arc(145, 45, 15, 0, (Math.PI / 180) * 360);
                c.stroke();
            }
            if (self.ChancesLeft() < 5) {
                // draw body
                drawLine(c, [145, 60], [145, 130]);
            }
            if (self.ChancesLeft() < 4) {
                // draw left arm
                drawLine(c, [145, 80], [110, 90]);
            }
            if (self.ChancesLeft() < 3) {
                // draw right arm
                drawLine(c, [145, 80], [180, 90]);
            }
            if (self.ChancesLeft() < 2) {
                // draw left leg
                drawLine(c, [145, 130], [130, 170]);
            }
            if (self.ChancesLeft() < 1) {
                // draw right leg and end game
                drawLine(c, [145, 130], [160, 170]);
                c.fillText('Game over', 45, 110);
            }
        }
    }
}

function drawLine(context, from, to) {
    context.beginPath();
    context.moveTo(from[0], from[1]);
    context.lineTo(to[0], to[1]);
    context.stroke();
}