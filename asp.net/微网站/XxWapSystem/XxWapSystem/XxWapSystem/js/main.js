
//���ݽ��ܸ���
$(document).ready(function() {

    //�����۵�
    var project_info_show = false;
    $("#info_box_project_info .info_content").css("height", "auto");
    $("#info_box_project_info_btn").click(function() {
        project_info_show = !project_info_show;
        if (project_info_show) {
            $("#info_box_project_info_btn").html('<i class="icon_down"></i>չ��');
            $("#info_box_project_info .info_content").css("height", "75px");
        } else {
            $("#info_box_project_info_btn").html('<i class="icon_up"></i>����');
            $("#info_box_project_info .info_content").css("height", "auto");
        }
    });
    //�����۵�
    var project_show = false;
    $("#info_box_project_intro .info_content").css("height", "auto");
    $("#info_box_project_intro_btn").click(function() {
        project_show = !project_show;
        if (project_show) {
            $("#info_box_project_intro_btn").html('<i class="icon_down"></i>չ��');
            $("#info_box_project_intro .info_content").css("height", "25px");
        } else {
            $("#info_box_project_intro_btn").html('<i class="icon_up"></i>����');
            $("#info_box_project_intro .info_content").css("height", "auto");
        }

    });
    //������׼�۵�
    var project_jf_show = true;
    $("#info_box_project_jfbz .info_content").css("height", "25px");
    $("#info_box_project_jfbz_btn").click(function() {
        project_jf_show = !project_jf_show;
        if (project_jf_show) {
            $("#info_box_project_jfbz_btn").html('<i class="icon_down"></i>չ��');
            $("#info_box_project_jfbz .info_content").css("height", "25px");
        } else {
            $("#info_box_project_jfbz_btn").html('<i class="icon_up"></i>����');
            $("#info_box_project_jfbz .info_content").css("height", "auto");
        }

    });
    //������Ϣ�۵�
    var project_pt_show = true;
    $("#info_box_project_ptxx .info_content").css("height", "25px");
    $("#info_box_project_ptxx_btn").click(function() {
        project_pt_show = !project_pt_show;
        if (project_pt_show) {
            $("#info_box_project_ptxx_btn").html('<i class="icon_down"></i>չ��');
            $("#info_box_project_ptxx .info_content").css("height", "25px");
        } else {
            $("#info_box_project_ptxx_btn").html('<i class="icon_up"></i>����');
            $("#info_box_project_ptxx .info_content").css("height", "auto");
        }

    });

    //����Ϣ�۵�
    var project_d_show = true;
    $("#info_box_project_building .info_content").css("height", "275px");
    $("#info_box_project_building_btn").click(function() {
        project_d_show = !project_d_show;
        if (project_d_show) {
            $("#info_box_project_building_btn").html('<i class="icon_down"></i>չ��');
            $("#info_box_project_building .info_content").css("height", "275px");
        } else {
            $("#info_box_project_building_btn").html('<i class="icon_up"></i>����');
            $("#info_box_project_building .info_content").css("height", "auto");
        }
    });
    /*
    $("body").add($(window)).bind("scroll", function () {
    var st = $(document).scrollTop();
    (st > 50) ?  $("#call_bar").fadeIn(500) :  $("#call_bar").fadeOut(500);
    });
    */
    $("#btn_back").click(function() {
        goback();
    });


    $("#app_down_close").click(function() {
        $("#app_down_fullad").hide();

        //���iOS ��
        if (navigator.userAgent.match(/(iPhone|iPod|iPad);?/i)) {
            //$("#app-open-bar").show();
        } else {
            //$("#app-download-bar").show();
            //$("#app-open-bar").hide();
        }
    });


    $("#bbs_app_open_btn").click(function() {
        //$("#app_down_fullad").hide();

        //���iOS ��
        if (navigator.userAgent.match(/(iPhone|iPod|iPad);?/i)) {
            //$("#app-open-bar").show();
        } else {
            //$("#app-download-bar").show();
            //$("#app-open-bar").hide();
        }
    });


    $("#btn_gotop").goTop();


    $("#closetip").click(function() {
        $("#app-download-bar").hide();
        setCookie('closetip', true);
    });

    $("#openapp").click(function() {
        open_app();
    });
    $("#app_download_btn").click(function() {
        download_app();
    });
    $("#app_open_close").click(function() {
        $("#app-open-bar").hide();
        setCookie('app-open-close', true);
    });

    $("#choose_title").click(function() {
        $("#choose_opts").show();
    });

    $("#app-popup_close").click(function() {
        $("#app-popup-wrap").hide();
    });
    $("#app-popup_btn").click(function() {
        open_app();
    });


    if (navigator.cookieEnabled && getCookie('app-open-close') == null) {
        //$("#app-download-bar").show();
        //$("#app-open-bar").show(); 
    } else {
        //$("#app-open-bar").show();
        //$("#app-download-bar").show();
    }


    //ȫ�����
    $("#app_down_fullad").show();



});



