let files;
let images = [];
let arrayLength = 0;

function onChange(event) {
    files = event.target.files;
    for (let i = 0; i < files.length; i++) {
        let check = addToArray(files[i]);
        arrayLength = images.length;
        if (check) {
            showItem(files[i].size, files[i].lastModified, arrayLength, i);
        }
        else {
            alert("Файл: " + files[i].name + " вже був добавлений!!!");
        }
    }
    // document.getElementById("fileInputControl").value = "";
    console.log(images);
}

function addToArray(item) {
    let ifExist = checkBySize(item);
    if (ifExist) {
        return false;
    }
    else {
        images.push(item);
        return true;
    }
}

function checkBySize(item) {
    for (let i = 0; i < images.length; i++) {
        if (images[i].size === item.size) {
            return true;
        }
    }
    return false;
}

function showItem(fileSize, fileLastModified, arrayLength, i) {
    let div = document.createElement("div");
    div.setAttribute('class', 'col-12 col-sm-6 col-md-4 col-lg-3 imageItem');
    div.innerHTML = `
        <h3 class="test" id="`+ (arrayLength - 1) + `">` + (arrayLength - 1) + `</h3>
        <div class="checkBox">
            <input type="checkbox" class="cover" id="`+ fileLastModified + `" onclick="selectOnlyThis(this.id)" title="Зробити обкладинкою" name="PhotoAlbum.Photos[` + (arrayLength - 1) + `].IsCover" value="false">
            <label for="`+ fileLastModified + `">Вибрати обкладинкою</label>
        </div>
        </div>
        <div class="remove" id="`+ fileSize + `" onclick="deleteItem(this.id)" title="Видалити">❌</div>
        <img class="thumb" src="`+ URL.createObjectURL(event.target.files[i]) + `">
        <div class="input-group input-group-sm mb-3">
            <input type="text" class="form-control" placeholder="Назва фото" name="PhotoAlbum.Photos[`+ (arrayLength - 1) + `].Title">
        </div>`;
    document.querySelector('.output').insertBefore(div, null);
    let thumb = document.querySelectorAll('.thumb');
    thumb.onload = function () {
        URL.revokeObjectURL(thumb.src);
        alert("URL.revokeObjectURL");
    }
};

function deleteItem(id) {
    let selectedIdRemove = Number(id);
    for (let i = 0; i < images.length; i++) {
        if (images[i].size === selectedIdRemove) {
            images.splice(i, 1);
            document.getElementById(id).parentElement.setAttribute("style", "opacity: 0");
            setTimeout(() => {
                document.getElementById(id).parentElement.remove();
            }, 500);
        }
    }
    console.log(images);
    setTimeout(() => {
        numRestruct();
    }, 1000);
}

function selectOnlyThis(id) {
    for (let i = 0; i < images.length; i++) {
        document.getElementById(images[i].lastModified).checked = false;
    }
    document.getElementById(id).checked = true;
}

function numRestruct() {
    let testArr = document.querySelectorAll(".cover");
    console.log(testArr);
    for (let i = 0; i < testArr.length; i++) {
        testArr[i].name = `PhotoAlbum.Photos[` + i + `].Title`;
        document.getElementById(testArr[i].id).innerHTML = i;
    }
    console.log(testArr);
}