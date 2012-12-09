function List_R_Nav_on(id) {
    var get_Ul = document.getElementById("Right_Alert_Nav_List");
    var get_Li_l = get_Ul.getElementsByTagName("li").length;
    var get_ie6_fix = document.getElementById("fix_ie6_brders");
    var get_Li_count = get_Ul.getElementsByTagName("li").length;
    get_ie6_fix.className = 'fix_ie6_rit_border_o';
    get_ie6_fix.style.height = get_Li_count * 73 + 19 + 'px';
    if (get_Li_l > 3) {
        get_Ul.style.height = 'auto';
        get_Ul.style.paddingBottom = '18px';
    }
    else {
        get_Ul.style.height = '239px';
        get_ie6_fix.style.height = '239px';
    }
    get_Ul.style.overflow = 'visible';
    id.style.border = '2px #800000 solid';
    id.style.left = '-2px';
    id.style.width = '197px';
    id.getElementsByTagName("span")[0].style.display = 'block';
    id.getElementsByTagName("div")[0].style.left = '2px';
    id.getElementsByTagName("div")[0].style.borderBottom = '1px white solid';
    id.getElementsByTagName("div")[3].style.border = '2px #800000 solid';
    id.getElementsByTagName("div")[3].style.width = '480px';
    id.getElementsByTagName("div")[3].style.height = 'auto';
}

function List_R_Nav_off(id) {
    var get_Ul = document.getElementById("Right_Alert_Nav_List");
    var get_ie6_fix = document.getElementById("fix_ie6_brders");
    var get_Li_count = get_Ul.getElementsByTagName("li").length;
    get_ie6_fix.className = 'fix_ie6_rit_border';
    get_ie6_fix.style.height = get_Li_count * 73 + 1 + 'px';
    var get_Ul = document.getElementById("Right_Alert_Nav_List");
    get_Ul.style.height = '239px';
    get_Ul.style.overflow = 'hidden';
    id.style.border = '2px white solid';
    id.style.left = '0px';
    id.style.width = '194px';
    id.getElementsByTagName("span")[0].style.display = 'none';
    id.getElementsByTagName("div")[0].style.left = '0px';
    id.getElementsByTagName("div")[0].style.borderBottom = '1px #cccccc dashed';
    id.getElementsByTagName("div")[3].style.border = '0px';
    id.getElementsByTagName("div")[3].style.width = '0px';
    id.getElementsByTagName("div")[3].style.height = '0px';
    get_Ul.style.paddingBottom = '0px';
}

function List_Nav_R() {
    var get_Ul = document.getElementById("Right_Alert_Nav_List");
    var get_Li = get_Ul.getElementsByTagName("li");
    for (var i = 0; i < get_Li.length; i++) {
        get_Li[i].onmouseover = function () {
            List_R_Nav_on(this);
        };
        get_Li[i].onmouseout = function () {
            List_R_Nav_off(this);
        };
    }
}

function picclick() {
    var small_img_set_id = document.getElementById("right_small_img_set");
    var get_span = small_img_set_id.getElementsByTagName("span");
    for (var i = 0; i < get_span.length; i++) {
        get_span[i].onclick = function () {
            Demo_R_C(this);
        }
    }
}

function Demo_R_C(ts) {
    var m_img = document.getElementById("midium_imgs");
    var m_img_b = document.getElementById("big_suol_img");
    var small_img_set_ids = document.getElementById("right_small_img_set");
    var get_spans = small_img_set_ids.getElementsByTagName("span");
    m_img.src = ts.getElementsByTagName("img")[1].src;
    m_img_b.href = ts.getElementsByTagName("img")[1].src;
    for (var j = 0; j < get_spans.length; j++) {
        get_spans[j].getElementsByTagName("div")[1].className = 'right_imgs_dm_off';
        get_spans[j].getElementsByTagName("img")[0].style.display = 'none';
    }
    ts.getElementsByTagName("div")[1].className = 'right_imgs_dm_on';
    ts.getElementsByTagName("img")[0].style.display = 'block';
}