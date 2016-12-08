function toggleMenu() {
    vm.ShowMenu = vm.ShowMenu === true ? false : true;
}

function updateResume() {

}

function updateResumeContactInfo() {

}

function updateResumeSection() {

}

function updateResumeEntry() {

}


Vue.component('tb-menu',
{
    template: '#tb-menu',
    props: {
        show: {
            type: Boolean,
            required: true,
            twoWay: true
        },
        show_menu: {
            type: Boolean,
            required: true,
            twoWay: true
        },
        ToggleMenu: {
            type: Function,
            default: function () {
                vm.ShowMenu = vm.ShowMenu === true ? false : true;
            }
        }
    }
});


Vue.component('tb-resume-contact-info',
{
    template: '#tb-resume-contact-info',
    props: {
        show: {
            type: Boolean,
            required: true,
            twoWay: true
        },
        content: {
            type: Object
        }
    }
});

Vue.component('tb-resume-section',
{
    template: '#tb-resume-section',
    props: {
        show: {
            type: Boolean,
            required: true,
            twoWay: true
        },
        content: {},
    }
});

Vue.component('tb-resume-entry',
{
    template: '#tb-resume-entry',
    props: {
        show: {
            type: Boolean,
            required: true,
            twoWay: true
        },
        content: {}
    }
});


Vue.component('tb-resume-tags',
{
    template: '#tb-resume-tags',
    props: {
        show: {
            type: Boolean,
            required: true,
            twoWay: true
        },
        content: {}
    }
});


function getResume() {
    vm.Loading = true;
    $.ajax({
        url: "http://localhost:50350/api/resume",
        data: { 'id': 1 },
        type: 'get',
        dataType: 'json',
        error: function (xhr) {
            $("#message").text(xhr.statusText);
        },
        success: function (result) {
            vm.Content = result;
            vm.Section = true;
            vm.Contact = true;
            vm.Loading = false;
        }
    });
}


Vue.filter('date',
    function (indate, sad) {
        if (sad) {
            return "Nuvarande";
        }
        var date = moment(indate);
        return date.locale("sv").format("MMM YYYY");
    });

Vue.filter('sort',
    function (data) {
        return data.entries.sort(function (a, b) {
            return b.sorter - a.sorter;
        })
    });

Vue.filter('section_sorter',
    function (data) {
        return data.sort(function (a, b) {
            return b.sorter - a.sorter;
        })
    });


var vm = new Vue
({
    el: '#app',
    data:
    {
        Loading: true,
        Section: false,
        Contact: false,
        ShowMenu: false,
        String: string,
        Content: {}
    },
    methods: {
        ToggleMenu: toggleMenu,
        UpdateResume: updateResume,
        UpdateResumeContactInfo: updateResumeContactInfo,
        UpdateResumeSection: updateResumeSection,
        UpdateResumeEntry: updateResumeEntry
    }
});

getResume();