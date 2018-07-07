var formatDateComplete = function (data) {

    if (typeof (data) === 'undefined' || data === "") return "";

    var dt = new Date(data.replace(/-/g, '/'));



    //var dt = new Date(data);

    var d = dt.getDate();
    var m = dt.getMonth() + 1;
    var a = dt.getFullYear();
    var hh = dt.getHours();
    var mn = dt.getMinutes();

    return (d < 10 ? "0" : "") + d + "/" + (m < 10 ? "0" : "") + m + "/" + a + " " + (hh < 10 ? "0" : "") + hh + ":" + (mn < 10 ? "0" : "") + mn;

}


var formatDate = function (data) {

    if (typeof (data) === 'undefined' || data === "") return "";

    //var dt = new Date(data);
    var dt = new Date(data.replace(/-/g, '/'));

    var d = dt.getDate();
    var m = dt.getMonth() + 1;
    var a = dt.getFullYear();


    return (d < 10 ? "0" : "") + d + "/" + (m < 10 ? "0" : "") + m + "/" + a;

}





var IsNull = function (o, ret) {
    if (typeof (o) === 'undefined') {
        return ret;
    } else {
        return o;
    }


}


function isEmptyOrSpaces(str) {
    return str === null || str.match(/^ *$/) !== null;
}



/**************************************************************** TRATAMENTO DE IMAGENS **************************************************************/



var gerathumb = function (e) {

    var id_controle = e.target.id;
    var canvas = document.getElementById(id_controle + "_thumb");
    var ctx = canvas.getContext('2d');
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    var reader = new FileReader();

    reader.onload = function (event) {

        var img = new Image();
        img.onload = function () {

            canvas.width = img.width;
            canvas.height = img.height;


            //Carrega a orientação e gira a imagem caso a próatividade de merda do navegador sacaneie
            getOrientation(e.target.files[0], function (orientation) {

                // set proper canvas dimensions before transform & export
                if (4 < orientation && orientation < 9) {
                    canvas.width = img.height;
                    canvas.height = img.width;
                } else {
                    canvas.width = img.width;
                    canvas.height = img.height;
                }


                switch (orientation) {
                    case 2: ctx.transform(-1, 0, 0, 1, img.width, 0); break;
                    case 3: ctx.transform(-1, 0, 0, -1, img.width, img.height); break;
                    case 4: ctx.transform(1, 0, 0, -1, 0, img.height); break;
                    case 5: ctx.transform(0, 1, 1, 0, 0, 0); break;
                    case 6: ctx.transform(0, 1, -1, 0, img.height, 0); break;
                    case 7: ctx.transform(0, -1, -1, 0, img.height, img.width); break;
                    case 8: ctx.transform(0, -1, 1, 0, 0, img.width); break;
                    default: break;
                }

                ctx.drawImage(img, 0, 0);
            });



        }
        img.src = event.target.result;


        //desativa a img referente ( imagem atual )
        $("#img_thumbnail").hide();


        $(canvas).show();

    }
    reader.readAsDataURL(e.target.files[0]);

}


function getOrientation(file, callback) {
    var reader = new FileReader();
    reader.onload = function (e) {

        var view = new DataView(e.target.result);
        if (view.getUint16(0, false) != 0xFFD8) {
            return callback(-2);
        }
        var length = view.byteLength, offset = 2;
        while (offset < length) {
            if (view.getUint16(offset + 2, false) <= 8) return callback(-1);
            var marker = view.getUint16(offset, false);
            offset += 2;
            if (marker == 0xFFE1) {
                if (view.getUint32(offset += 2, false) != 0x45786966) {
                    return callback(-1);
                }

                var little = view.getUint16(offset += 6, false) == 0x4949;
                offset += view.getUint32(offset + 4, little);
                var tags = view.getUint16(offset, little);
                offset += 2;
                for (var i = 0; i < tags; i++) {
                    if (view.getUint16(offset + (i * 12), little) == 0x0112) {
                        return callback(view.getUint16(offset + (i * 12) + 8, little));
                    }
                }
            }
            else if ((marker & 0xFF00) != 0xFF00) {
                break;
            }
            else {
                offset += view.getUint16(offset, false);
            }
        }
        return callback(-1);
    };
    reader.readAsArrayBuffer(file);
}



Number.prototype.pad = function (size) {
    var s = String(this);
    while (s.length < (size || 2)) { s = "0" + s; }
    return s;
}

String.prototype.pad = function (size) {
    var s = String(this);
    while (s.length < (size || 2)) { s = "0" + s; }
    return s;
}

