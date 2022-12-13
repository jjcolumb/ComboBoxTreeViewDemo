function SetTreeWidht() {
    
    var box = document.querySelector('.dropdown-width');
    var swidth = box.offsetWidth;

    var elem = document.querySelector('.treeview-categories');
    elem.style.width = swidth + "px";

}