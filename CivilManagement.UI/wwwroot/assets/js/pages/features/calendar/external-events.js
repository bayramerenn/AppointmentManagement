var KTCalendarExternalEvents = function () {

    var initExternalEvents = function () {
        $('#kt_calendar_external_events .fc-draggable-handle').each(function () {
            // store data so the calendar knows to render an event upon drop
            $(this).data('event', {
                title: $.trim($(this).text()), // use the element's text as the event title
                stick: true, // maintain when user navigates (see docs on the renderEvent method)
                classNames: [$(this).data('color')],
                description: 'Lorem ipsum dolor eius mod tempor labore'
            });
        });
    }

    var initCalendar = function () {
        var todayDate = moment().startOf('day');
        var YM = todayDate.format('YYYY-MM');
        var YESTERDAY = todayDate.clone().subtract(1, 'day').format('YYYY-MM-DD');
        var TODAY = todayDate.format('YYYY-MM-DD');
        var TOMORROW = todayDate.clone().add(1, 'day').format('YYYY-MM-DD');

        var calendarEl = document.getElementById('kt_calendar');
        var containerEl = document.getElementById('kt_calendar_external_events');

        var Draggable = FullCalendarInteraction.Draggable;

        new Draggable(containerEl, {
            itemSelector: '.fc-draggable-handle',
            eventData: function (eventEl) {
                return $(eventEl).data('event');
            }
        });

        var calendar = new FullCalendar.Calendar(calendarEl, {
            plugins: ['interaction', 'dayGrid', 'timeGrid', 'list'],

            isRTL: KTUtil.isRTL(),
            locale: 'tr',
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'dayGridMonth,timeGridWeek,timeGridDay,listWeek'

            },

            footer: {
                left: 'prevYear',
                right: 'nextYear'
            },
            minTime: '08:00:00',
            maxTime: '16:00:00',

            //weekends: false,

            //slotDuration: '00:15:00',
            //slotLabelInterval:'00:15:00',

            snapDuration: '00:15:00',
            slotLabelFormat: {
                hour: '2-digit',
                minute: '2-digit'
            },
            columnHeaderFormat: {
                weekday: 'long'
            },

            fixedWeekCount: true,
            height: 800,
            contentHeight: 780,
            aspectRatio: 1.2,  // see: https://fullcalendar.io/docs/aspectRatio

            nowIndicator: true,
            now: TODAY + 'T12:00:00', // just for demo

            views: {
                dayGridMonth: { buttonText: 'month' },
                timeGridWeek: { buttonText: 'week' },
                timeGridDay: { buttonText: 'day' }
            },

            //defaultView: 'dayGridWeek',
            defaultView: 'timeGridWeek',
            defaultDate: TODAY,

            hiddenDays: [0],
            allDaySlot: false,
            droppable: true, // this allows things to be dropped onto the calendar
            editable: true, //Event üzerinde güncelleme yaptýrýr
            eventLimit: true, // allow "more" link when too many events
            navLinks: true,

            timeZone: 'UTC',
            events: [
                {
                    id: 1,
                    title: 'Otomobil',
                    start: "2020-07-22T09:00:00Z",
                    end: "2020-07-22T10:00:00Z",
                    description: 'Toto lorem ipsum dolor sit incid idunt ut',
                    test: "budan bende",
                    className: "fc-event-danger fc-event-solid-warning"
                },
                {
                    id: 2,
                    title: 'Kamyon',
                    start: "2020-07-22T14:02:00Z",
                    end: "2020-07-22T15:00:00Z",
                    description: 'Toto lorem ipsum dolor sit incid idunt ut',
                    className: "fc-event-danger fc-event-solid-success"
                },
                {
                    id: 2,
                    title: 'Tir',
                    start: "2020-07-23T12:02:00Z",
                    end: "2020-07-23T15:00:00Z",
                    description: 'Toto lorem ipsum dolor sit incid idunt ut',
                    className: "fc-event-danger fc-event-solid-primary"
                },

            ],

            selectable: true,

            select: function (selectionInfo) {
                console.log(selectionInfo)
            },

            drop: function (arg) {
                // is the "remove after drop" checkbox checked?
                if ($('#kt_calendar_external_events_remove').is(':checked')) {
                    // if so, remove the element from the "Draggable Events" list
                    $(arg.draggedEl).remove();
                }
            },

            eventClick: function (info) {
                alert(info.event)

            },

            eventRender: function (info) {

                //console.log(info.event.extendedProps.test)
                //var element = $(info.el);

                //console.log(element);s

                //console.log(info.event);
                //console.log(info.allDay());

                //if (info.event.extendedProps && info.event.extendedProps.description) {
                //    console.log("if");
                //}


                //if (info.event.extendedProps && info.event.extendedProps.description) {
                //    if (element.hasClass('fc-day-grid-event')) {
                //        element.data('content', info.event.extendedProps.description);
                //        element.data('placement', 'top');
                //        KTApp.initPopover(element);
                //    } else if (element.hasClass('fc-time-grid-event')) {
                //        element.find('.fc-title').append('<div class="fc-description">' + info.event.extendedProps.description + '</div>');
                //    } else if (element.find('.fc-list-item-title').lenght !== 0) {
                //        element.find('.fc-list-item-title').append('<div class="fc-description">' + info.event.extendedProps.description + '</div>');
                //    }
                //}


            },

            eventDragStart: function (info) {
                console.log("basladi");
            },
            eventDragStop: function (info) {
                console.log("bitti");
            },
            eventDrop: function (info) {
                console.log("drop");
            }

        });

        calendar.render();

        //var events = calendar.getEvents();


        //var event = calendar.getEventById("1");
        //console.log(event.remove());



    }

    return {
        //main function to initiate the module
        init: function () {
            initExternalEvents();
            initCalendar();
        }
    };
}();

jQuery(document).ready(function () {
    KTCalendarExternalEvents.init();
});
