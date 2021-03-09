class Toast {

    getToast(status, message) {
        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-bottom-right",
            "preventDuplicates": false,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            //"showEasing": "swing",
            //"hideEasing": "linear",
            //"showMethod": "fadeIn",
            //"hideMethod": "fadeOut"
        };

        switch (status) {

            case 'error':
                toastr.error(message);
                break;
            case 'primary':
                toastr.primary(message);
                break;
            case 'warning':
                toastr.warning(message);
                break;
            case 'success':
                toastr.success(message);
                break;
        }
        
    }
}