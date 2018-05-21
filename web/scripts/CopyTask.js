var events = []; //array to keep all events
var initialDowntime = 0; //start time of first key event
var questionInitialDowntime = 0;
var sessionObject = sessionInfo(); // keeps track of the sessionInformation
var qAnswers = questionnaireAnswers(); // keeps track of questionnaire answers
var isFirstKeyPress = true;     //is used to start timer after first key press

$(document).ready(function () {
    var logevent;
    var message = '';

    (function ($, undefined) {
        $.fn.getCursorPosition = function () {
            var el = $(this).get(0);
            var pos = 0;
            if ('selectionStart' in el) {
                pos = el.selectionStart;
            } else if ('selection' in document) {
                el.focus();
                var Sel = document.selection.createRange();
                var SelLength = document.selection.createRange().text.length;
                Sel.moveStart('character', -el.value.length);
                pos = Sel.text.length - SelLength;
            }
            return pos;
        }
    })(jQuery);

    /*Fires when the user depresses a key while in inputarea.
    It repeats while the user keeps the key depressed.*/
    $("#inputarea").keydown(function (event) {
        if(isFirstKeyPress){
            startTimer();       //function in tasks.html
            isFirstKeyPress = false;
        }

        //
        // prevents enter/return to execute new line
        //
        var maxRows = this.rows;

        /*
         * If there's an unlimited amount of repetitions allowed, the enter/return
         * will never be ignored. And the text field will grow with each enter.
         * 
         * Otherwise, we will have to check whether the max number of rows (repetitions) has not
         * been passed yet.
         */
       if(ffa_repetition && event.which === 13){
            this.rows += 1;
        } else {
            /* 
             * No enters allowed when you're already at the maximum amount of rows
             * > EXCEPT IF: the current last row is whitespace and/or empty, then we 
             * remove this row.
             */
            if(this.value.lineCount() >= maxRows && 
                    event.which === 13) {
                var textAreaContentLines = this.value.lines();
                if (textAreaContentLines[maxRows - 1] === "") {
                    var currentCursorPosition = $("#inputarea").getCursorPosition();
                    var lastRowToKeep = (maxRows > 1) ? maxRows - 2 : 0;
                    this.value = textAreaContentLines.slice(0, lastRowToKeep + 1).join("\r\n");
                    var tmpLines = this.value.lines();
                    this.setSelectionRange(currentCursorPosition, currentCursorPosition);

                } else {
                    event.preventDefault();
                }
            }
            // 
            // No enters allowed when there's only one row to be typed
            //
            if (maxRows === 1 && event.keyCode === 13){
                event.preventDefault();
            }
        }

        var myChar = specialCharacter(event.keyCode, event.Key);
        var keyCode = myChar.key;
        var keyValue = myChar.value;

        if (events.length == 0) //the time of the first event serves as the baseline for the timer
        {
            initialDowntime = window.performance.now();
        }

        var time = window.performance.now() - initialDowntime;

        //document length and position
        var area = $("#inputarea")[0];
        var docLength = area.value.length;
        var cursorPosition = $("#inputarea").getCursorPosition();

        logevent = { keyCode: keyCode, keyValue: keyValue, downtime: time, type: 'keyEvent', position: cursorPosition, docLength: docLength };

        events.push(logevent);


    });

    /*Fires when an actual character is being inserted in inputarea.
    It repeats while the user keeps the key depressed.*/
    $("#inputarea").keypress(function (event) {
        var keyValue = String.fromCharCode(event.charCode);
        var keyValue2 = String.fromCharCode(event.keyCode);

        var currEvent = events[events.length - 1];
        if (currEvent.keyValue == null && currEvent.keyCode != null) {      //this means the key was a special character, but the key value was not known at the time of the keydown event
            events[events.length - 1].keyValue = keyValue;
        } else if (currEvent.keyCode == null){              //this means the key was not a special character
            events[events.length - 1].keyCode = "VK_" + keyValue.toUpperCase();
            events[events.length - 1].keyValue = keyValue;
        }
        
    });

    /*Fires when the user releases a key,
    after the default action of that key has been performed.*/
    $("#inputarea").keyup(function (event) {
        var uptime = window.performance.now() - initialDowntime;
        if (uptime == 0) {
            uptime = events[events.length - 1].downtime;
        }
        events[events.length - 1].uptime = uptime;

        //document length and position
        var area = $("#inputarea")[0];
        var docLength = area.value.length;
        events[events.length - 1].docLength = docLength;
        var cursorPosition = $("#inputarea").getCursorPosition();
        events[events.length - 1].position = cursorPosition;

     
        //showOutput();

        // Check whether enough lines have been entered in the input area, in order to advance.
        setAdvanceAvailability();
    });

    function specialCharacter(charCode, keyValue) {

        standard_mapping = {
            8: {value: "&#x8;", key: "VK_BACK"},  // backspace
            9: {value: "    ", key: "VK_TAB"}, //  tab
            13: {value: "\r\n", key: "VK_RETURN"}, //  enter
            16: {value: "", key: "VK_SHIFT"}, //  shift
            17: {value: "", key: "VK_CONTROL"}, //  ctrl
            18: {value: "", key: "VK_MENU"}, //  alt
            19: {value: "", key: "VK_PAUSE"}, //  pause/break
            20: {value: "", key: "VK_CAPITAL"}, //  caps lock
            27: {value: "&#x1B},", key: "VK_ESCAPE"}, //  escape
            32: {value: " ", key: "VK_SPACE"},
            33: {value: "", key: "VK_PRIOR"}, // page up
            34: {value: "", key: "VK_NEXT"}, // page down
            35: {value: "", key: "VK_END"}, // end
            36: {value: "", key: "VK_HOME"}, // home
            37: {value: "", key: "VK_LEFT"}, // left arrow
            38: {value: "", key: "VK_UP"}, // up arrow
            39: {value: "", key: "VK_RIGHT"}, // right arrow
            40: {value: "", key: "VK_DOWN"}, // down arrow
            45: {value: "", key: "VK_INSERT"}, // insert
            46: {value: "", key: "VK_DELETE"}, // delete
            91: {value: "", key: "VK_LWIN"}, // left window
            92: {value: "", key: "VK_RWIN"}, // right window
            93: {value: "", key: "VK_APPS"}, // select key

            96: {value: "0", key: "VK_NUMPAD0"}, // numpad 0
            97: {value: "1", key: "VK_NUMPAD1"}, // numpad 1
            98: {value: "2", key: "VK_NUMPAD2"}, // numpad 2
            99: {value: "3", key: "VK_NUMPAD3"}, // numpad 3
            100: {value: "4", key: "VK_NUMPAD4"}, // numpad 4
            101: {value: "5", key: "VK_NUMPAD5"}, // numpad 5
            102: {value: "6", key: "VK_NUMPAD6"}, // numpad 6
            103: {value: "7", key: "VK_NUMPAD7"}, // numpad 7
            104: {value: "8", key: "VK_NUMPAD8"}, // numpad 8
            105: {value: "9", key: "VK_NUMPAD9"}, // numpad 9
            106: {value: "*", key: "VK_MULMTIPLUY"}, // multiply
            107: {value: "+", key: "VK_ADD"}, // add
            109: {value: "-", key: "VK_SUBTRACT"}, // subtract
            110: {value: ".", key: "VK_DECIMAL"}, // decimal point
            111: {value: "/", key: "VK_DIVIDE"}, // divide
            112: {value: "", key: "VK_F1"}, // F1
            113: {value: "", key: "VK_F2"}, // F2
            114: {value: "", key: "VK_F3"}, // F3
            115: {value: "", key: "VK_F4"}, // F4
            116: {value: "", key: "VK_F5"}, // F5
            117: {value: "", key: "VK_F6"}, // F6
            118: {value: "", key: "VK_F7"}, // F7
            119: {value: "", key: "VK_F8"}, // F8
            120: {value: "", key: "VK_F9"}, // F9
            121: {value: "", key: "VK_F10"}, // F10
            122: {value: "", key: "VK_F11"}, // F11
            123: {value: "", key: "VK_F12"}, // F12
            144: {value: "", key: "VK_NUMLOCK"}, // num lock
            145: {value: "", key: "VK_SCROLL"}, // scroll lock

            48: {value: null, key: "VK_0"},
            49: {value: null, key: "VK_1"}, 
            50: {value: null, key: "VK_2"}, 
            51: {value: null, key: "VK_3"}, 
            52: {value: null, key: "VK_4"},
            53: {value: null, key: "VK_5"},
            54: {value: null, key: "VK_6"},
            55: {value: null, key: "VK_7"},
            56: {value: null, key: "VK_8"},
            57: {value: null, key: "VK_9"},

            186: {value: null, key: "VK_OEM_1"},
            187: {value: null, key: "VK_OEM_PLUS"},
            188: {value: null, key: "VK_OEM_COMMA"},
            189: {value: null, key: "VK_OEM_MINUS"},
            190: {value: null, key: "VK_OEM_PERIOD"}, 
            191: {value: null, key: "VK_OEM_2"},
            192: {value: null, key: "VK_OEM_3"}, 
            219: {value: null, key: "VK_OEM_4"},
            220: {value: null, key: "VK_OEM_5"},
            221: {value: null, key: "VK_OEM_6"},
            222: {value: null, key: "VK_OEM_7"},
            226: {value: null, key: "vk_oem_102"}
        }

        if (!(charCode in standard_mapping)) {
            return { key: null, value: null };
        }

        var result = standard_mapping[charCode];
        if (result.value === null) {
            result.value = keyValue;
        }
        return result;
    }
});

function showOutput() {
    message = '';
    for (i = 0; i < events.length; i++) {
        var myevent = events[i];
        message += toHtml(myevent);
    }
    $("#output").html(message);
}



function toHtml(myevent) {
    /// <summary>Creates HTML code to present event in browser</summary>
    /// <param name="myevent" type="String">The event to be formatted in HTML</param>
    /// <returns type="String">The HTML string representing the event</returns>
    if (myevent.type == 'keyEvent') {
        message = '<tr align="center"><td>' + myevent.keyValue + ' (code ' + myevent.keyCode + ')' + '<td style="width:200px"> starttime ' + Math.round(myevent.downtime * 100) / 100
                                        + '<td style="width:200px"> endtime ' + Math.round(myevent.uptime * 100) / 100 + ' </tr>';
    } else if (myevent.type == 'focusEvent') {
        message = '<tr align="center"><td>' + myevent.title + '<td style="width:200px"> starttime ' + Math.round(myevent.downtime * 100) / 100
                                        + '<td style="width:200px"> endtime ' + Math.round(myevent.uptime * 100) / 100 + ' </tr>';
    }

    return message;
}

function generateGUID() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

function crlf() {
    return '\r\n';
}

function myToFixed(number, otherTime) {
    try {
        return number.toFixed();
    } catch (err) {
        try {
            return other.toFixed();
        } catch (err) {
            return 0;
        }
    }
}

function openElement(name) {
    return '<' + name + '>' + crlf();
}

function closeElement(name) {
    return '</' + name + '>' + crlf();
}

function createElement(name, value) {
    return '<' + name + '>' + value + '</' + name + '>' + crlf();
}

function entriesToXML(entries) {
    exml = '';
    for (var key in entries) {
        exml += '\t\t' + openElement('entry');
        exml += '\t\t\t' + createElement('key', key);
        exml += '\t\t\t' + createElement('value', entries[key]);
        exml += '\t\t' + closeElement('entry');
    }
    return exml;
}

function getCurrentDate() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1;
    var yyyy = today.getFullYear();

    if (dd < 10) {
        dd = '0'+dd;
    }
    if (mm < 10) {
        mm = '0'+mm;
    }
    var sep = '-'
    var todayString = dd + sep + mm + sep + yyyy;
    return todayString;
}

function eventsToXML(events) {
    xml_string = '';
    xml_string += '<?xml version="1.0" encoding="utf-8"?>' + crlf();
    xml_string += openElement('log');
    
    var fileName = sessionObject.getParticipant() + '_' + copytaskName + '_' + getCurrentDate() + ".idfx";

    xml_string += '\t' + openElement('meta');
    var meta = {
        __LogProgramVersion: "6.1.2.0",
        __LogCreationDate: new Date().format("d/m/y H:m:s.u"),
        __GUID: generateGUID(),
        __LogRelativeCreationDate: 0,
        __LogFileName: fileName,
        __copytask: active_copytask_content,
    };
    xml_string += entriesToXML(meta);
    xml_string += '\t' + closeElement('meta');

    xml_string += '\t' + openElement('session');
    var session = {
        Participant: sessionObject.getParticipant(),
        "Text Language": sessionObject.getLanguage(),
        Age: sessionObject.getAge(),
        Gender: sessionObject.getGender(),
        Session: sessionObject.getSession(),
        Keyboard: sessionObject.getLayout(),
        Group: '',
        Experience: '',
        "Restricted Logging": ''
    };
    xml_string += entriesToXML(session);
    xml_string += '\t' + closeElement('session');


    for (i = 0; i < events.length; i++) {
        var myevent = events[i];
        if (myevent.type == 'keyEvent') {
            xml_string += '\t<event type="keyboard" id="' + i + '">' + crlf();

            xml_string += '\t\t<part type="wordlog">' + crlf();
            xml_string += '\t\t\t' + createElement('position', myevent.position);
            xml_string += '\t\t\t' + createElement('documentLength', myevent.docLength);
            xml_string += '\t\t\t' + createElement('replay', 'True');
            xml_string += '\t\t</part>' + crlf();

            xml_string += '\t\t<part type="winlog">' + crlf();

            xml_string += '\t\t\t' + createElement('startTime', myToFixed(myevent.downtime, myevent.uptime));
            xml_string += '\t\t\t' + createElement('endTime', myToFixed(myevent.uptime, myevent.downtime));

            var myKey = myevent.keyCode;
            if(myKey == null){
                myKey = 'VK_1';
            }

            var myValue = myevent.keyValue;
            if(myValue == null){
                myValue = '|';
            } else if (myValue == '&') {
                myValue = '&amp;';
            } else if (myValue == '<') {
                myValue = '&lt;';
            } else if (myValue == '>') {
                myValue = "&gt;";
            }

            xml_string += '\t\t\t' + createElement('key', myKey);
            xml_string += '\t\t\t' + createElement('value', myValue);
            xml_string += '\t\t\t<keyboardstate/>' + crlf();
            xml_string += '\t\t</part>' + crlf();
            xml_string += '\t</event>' + crlf();
        }
        else if (myevent.type == 'focusEvent') {
            xml_string += '\t<event type="focus" id="' + i + '">' + crlf();
            xml_string += '\t\t<part type="winlog">' + crlf();

            xml_string += '\t\t\t' + createElement('title', myevent.title);
            xml_string += '\t\t\t' + createElement('startTime', myToFixed(myevent.downtime, myevent.uptime));
            xml_string += '\t\t\t' + createElement('endTime', myToFixed(myevent.uptime, myevent.downtime));

            xml_string += '\t\t</part>' + crlf();
            xml_string += '\t</event>' + crlf();
        }
    }

    // Save questionnaire in a final event
    xml_string += '\t<event type="questions" id="' + i + '">' + crlf();
    xml_string += '\t\t<part type="winlog">' + crlf();
    xml_string += '\t\t\t' + createElement('handedness', qAnswers.get_handedness_score().toString());
    xml_string += '\t\t\t' + createElement('computer', qAnswers.get_computer());
    xml_string += '\t\t\t' + createElement('keyboard', qAnswers.get_keyboard_familiarity());
    xml_string += '\t\t\t' + createElement('browser', qAnswers.get_browser());
    xml_string += '\t\t\t' + createElement('language', qAnswers.get_languages());
    xml_string += '\t\t\t' + createElement('disorder', qAnswers.get_disorder().toString());
    xml_string += '\t\t\t' + createElement('education', qAnswers.get_education());
    xml_string += '\t\t\t' + createElement('repetition', qAnswers.get_repetition().toString());
    xml_string += '\t\t</part>' + crlf();
    xml_string += '\t</event>' + crlf();

    xml_string += closeElement('log');

    return xml_string;
}

function download(filename, text) {
    var pom = document.createElement('a');
    pom.setAttribute('href', 'data:text/plain;charset=utf-8,' + encodeURIComponent(text));
    pom.setAttribute('download', filename);
    pom.click();
}

// Add a method to a function, only if it does not exist yet.
Function.prototype.method = function (name, func) {
    if (!this.prototype[name]) {
        this.prototype[name] = func;
    }
}

function questionnaireAnswers() {
    var handednessScore = 0;
    var computer = "";
    var keyboard = "";
    var browser = "";
    var languages = "";
    var disorder = undefined;
    var education = "";
    var repetition = undefined;

    // Used for calculating handedness
    var handednessMap = {
        0: -100,
        1: -50,
        2: 0,
        3: 50,
        4: 100
    };

    return {
        reset: function() {
            handednessScore = 0;
            computer = "";
            browser = "";
            language = "";
            disorder = undefined;
            disorderSpecify = "";
            education = "";
            repetition = undefined;
        },
        add_handedness: function(handednessIndex) {
            handednessScore += handednessMap[handednessIndex];
        },
        get_handedness_score: function() { return handednessScore / 4; },
        set_computer: function(iComputer) { computer = iComputer; },
        get_computer: function() { return computer; },
        set_keyboard_familiarity: function (iKeyboard) { keyboard = iKeyboard;  },
        get_keyboard_familiarity: function() { return keyboard; },
        set_browser: function(iBrowser) { browser = iBrowser; },
        get_browser: function() { return browser; },
        set_languages: function(iLanguages) { languages = iLanguages; },
        get_languages: function() { return languages; },
        set_disorder: function(iDisorder) { disorder = iDisorder; },
        get_disorder: function() { return disorder; },
        set_education: function(iEducation) { education = iEducation; },
        get_education: function() { return education; },
        set_repetition: function(iRepetition) { repetition = iRepetition; },
        get_repetition: function() { return repetition; }
    };
}

function sessionInfo() {
    var participant;
    var age;
    var gender;
    var session;
    var language;
    var layout;

    var FALLBACK_LANGUAGE = "EN";

    return {
        reset: function () {
            participant = undefined;
            age = undefined;
            gender = undefined;
            session = undefined;
            language = undefined;
            layout = undefined;
        },
        setParticipant: function (iParticipant) {
            participant = iParticipant;
        },
        getParticipant: function () {
            if (participant === undefined) {
                return "Unknown";
            }
            return participant;
        },
        setAge: function (iAge) {
            age = iAge;
        },
        getAge: function () {
            if (age === undefined) {
                return "Unknown";
            }
            return age;
        },
        setGender: function (iGender) {
            gender = iGender;
        },
        getGender: function () {
            if (gender === undefined) {
                return "Unknown";
            }
            return gender;
        },
        setSession: function (iSession) {
            session = iSession;
        },
        getSession: function () {
            if (session === undefined) {
                return "Unknown";
            }
            return session;
        },
        setLanguage: function (iLanguage) {
            if (!isBlank(iLanguage)) {
                language = iLanguage;
            }
            else {
                language = FALLBACK_LANGUAGE;
            }
        },
        getFallbackLanguage: function() {
            return FALLBACK_LANGUAGE;
        },
        getLanguage: function () {
            if (language === undefined) {
                return "Unknown";
            }
            return language;
        },
        setLayout: function(iLayout) {
            if (!isBlank(iLayout)) {
                layout = iLayout;
            }
        },
        getLayout: function () {
            if (layout === undefined) {
                return "Unknown";
            }
            return layout;
        }
    };
}



/*
 * Returns the current day as dd-mm-yyyy
*/ 
function getTodayTimestamp() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; // January is 0
    var yyyy = today.getFullYear();

    if (dd < 10) {
        dd = '0' + dd;
    }
    if (mm < 10) {
        mm = '0' + mm; 
    }
    return dd + '-' + mm + "-" + yyyy;
}


function encode_filename(s) {
    if (s === '') {
        return '_';
    }
    return s.replace('/[^a-zA-Z0-9.-]/g', function (match) {
        return '_' + match[0].charCodeAt(0).toString(16) + '_';
    });
}

// Split a string into it's lines and return the lines in an array.
String.prototype.lines = function () {
    return this.split(/\r*\n/);
}

function isBlank(str) {
    return (!str || /^\s*$/.test(str));
}

// Return the number of lines in this string.
// If the string is an empty string, this function will return 0.
String.prototype.lineCount = function () {
    if (this.lines().length === 1 && this.lines()[0] === ""){
        return 0;
    }
    return this.lines().length; - (navigator.userAgent.indexOf("MSIE") != -1);
}

function arrayEquals(a, b) {
    if (a === b) return true;
    if (a == null || b == null) return false;
    if (a.length !== b.length) return false;
    for (var i = 0; i < a.length; ++i) {
        if (a[i] !== b[i]) return false;
    }
    return true;
}

// Find the index of needle for an array of strings.
// This function is case insensitive.
Array.prototype.indexOfCI = function (needle) {
    var upperNeedle = needle.toUpperCase();
    for(var i = 0; i < this.length; i++){
        if (typeof this[i] === "string" && this[i].toUpperCase() ===  upperNeedle) {
            return i;
        }
    }
    return -1;
}









