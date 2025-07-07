// ENABLE TOOLTIP
function enable_tooltip() {
    $(document).ready(function () {
        $('[data-toggle="tooltip"]').tooltip();
    });
}

// LOAD DARK LAYOUT
function dark_layout() {
    $(document).ready(function () {
        $("html").addClass("dark-layout");
    });
}

// LOAD ICON
function icon() {
    $(document).ready(function () {
        if (feather) {
            feather.replace({ width: 14, height: 14 });
        }
    });
}

// FIX HEADER TABLE
function datatable() {
    $(document).ready(function () {
        var table = $('table').DataTable({
            fixedHeader: {
                header: true
            },
            info: false,
            language: {
                search: "_INPUT_",
                searchPlaceholder: "Tìm kiếm...",
                lengthMenu: "Hiển thị _MENU_ dòng",
                paginate: {
                    previous: "Trước",
                    next: "Sau"
                }
            }
        });
    });
}

// FIX HEADER PROGRESS
function table_progress() {
    $(document).ready(function () {
        var table = $('table').DataTable({
            fixedHeader: {
                header: true
            },
            info: false,
            language: false
        });
    }); // END FIX HEADER TABLE
}

/* VERTICAL LAYOUT */
//---------------------------------------------------------
// CHANGE CLASS BODY
function vClassBody() {
    $(document).ready(function () {
        $("body").removeAttr("class");
        $("body").addClass("vertical-layout vertical-menu-modern navbar-floating footer-static");
        $("body").attr("data-menu", "vertical-menu-modern");
        $("body").attr("data-open", "click");
    });
}



/* HORIZONAL LAYOUT */
//---------------------------------------------------------
// CHANGE CLASS BODY
function hClassBody() {
    $(document).ready(function () {
        $("body").removeAttr("class");
        $("body").addClass("horizontal-layout horizontal-menu navbar-floating footer-static");
        $("body").attr("data-menu", "horizontal-menu");
        $("body").attr("data-open", "hover");
    });
}

function saveReport(filename, byteBase64) {
    var link = this.document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + byteBase64;
    this.document.body.appendChild(link);
    link.click();
    this.document.body.removeChild(link);
}

function navChildIdent() {
    if (!$('.nav-sidebar').hasClass('nav-child-indent')) {
        $('.nav-sidebar').addClass('nav-child-indent');
    };
}

function navCompact() {
    if (!$('.nav-sidebar').hasClass('nav-compact')) {
        $('.nav-sidebar').addClass('nav-compact');
    };
}

function select2() {
    $('.select2').select2({
        placeholder: "Select",
        allowClear: true
    }).on('select2:unselecting', function () {
        $(this).data('unselecting', true);
    }).on('select2:opening', function (e) {
        if ($(this).data('unselecting')) {
            $(this).removeData('unselecting');
            e.preventDefault();
        }
    }).on('change.select2', function (e) {
        var selectedVal = e.target.value;
        DotNet.invokeMethodAsync('OneApp.Client', 'UpdateModel', selectedVal);
        //BlazorApp - Your Application DLL Name
        //UpdateModel - Function Name [JSInvokable]
    });
}

function SetActive() {
    $('#carouselExampleIndicators').carousel(0);
}
function FocusControl(controlName) {
    document.getElementById(controlName).focus();
};
function EnableControl() {
    $(document).ready(function () {
        $('.select2-hidden-accessible').removeAttr('disabled');
    });
};
function UnCheckOnDetail() {
    $(document).ready(function () {
        $('input:checkbox').prop('checked', false);
    });
};
function SelectedDistribute(DistributeId) {
    $(document).ready(function () {
        $('#' + DistributeId).addClass('bg-selected-row');
    });
};
function UnSelectedDistribute() {
    $(document).ready(function () {
        $('.bg-selected-row').removeClass('bg-selected-row');
    });
};





