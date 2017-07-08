function preview(fileInput) {
    //console.log("in Preview");
    if (fileInput.files && fileInput.files[0]) {
        var reader = new FileReader();
        reader.onloadend = function (e) {
            $('#ImagePreview').attr('src', e.target.result);
        }
        reader.readAsDataURL(fileInput.files[0]);
    }
}