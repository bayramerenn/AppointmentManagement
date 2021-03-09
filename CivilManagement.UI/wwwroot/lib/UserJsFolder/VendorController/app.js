const tbody = document.getElementById("tableData");
const vendorCode = document.getElementById("vendorCode").value;
const modal = document.getElementById("myModal")
const saveAsnLine = document.getElementById("saveAsnLine")
const deleteItem = document.querySelectorAll(".card-body")[2]

let boxQuantity;
let palletQuantity;

const request = new Request();
const ui = new UI();

eventListeners()

function eventListeners() {
    modal.addEventListener("click", modalValidation);
    saveAsnLine.addEventListener("click", createAsnLine);
    deleteItem.addEventListener("click", trDelete)
}

function trDelete(el) {
    var request = new Request();

    console.log(el.target.className)

    if (el.target.className === "fa fa-trash") {
        swal.fire({
            title: 'Silmek istediğinizden emin misiniz?',
            text: "Bu işlem geri alınamaz!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Evet, Sil!',
            cancelButtonText: 'Hayır, Vazgeç!',
        }).then((result) => {
            if (result.value) {

                Swal.fire({
                    title: 'Silindi!',
                    text: 'İşleminiz başarıyla kaldırılmıştır.',
                    icon: 'success',
                    timer: 3500
                }).then(() => {
                    var id = el.target.getAttribute('id')


                    request.delete("Vendor/DeleteAsn", id)
                        .then(response => {
                            el.target.parentNode.parentNode.parentNode.parentNode.remove()
                        });
                });

            }
        });
    }
       


}

function modalValidation() {



    const warehouses = Array.from(document.querySelectorAll("#kt_select2_1>option"))
    const selectedWarehouseDesc = document.getElementById("select2-kt_select2_1-container").textContent;

    const vehicles = Array.from(document.querySelectorAll("#kt_select2_3>option"))
    const selectedVehicle = document.getElementById("select2-kt_select2_3-container").textContent;

    boxQuantity = parseInt(document.getElementById('BoxQuantity').value)
    palletQuantity = parseInt(document.getElementById('PalletQuantity').value)


    let filterVehicle = vehicles.filter((item) => selectedVehicle === item.textContent)
        .map((item) => {
            return item.value
        });

    let filterWarehouse = warehouses.filter((item) => selectedWarehouseDesc === item.textContent)
        .map((item) => {
            return item.value
        });



    if (filterWarehouse == 0) {
        ui.errorAlert('Depo seçmediniz!', 'error');

    } else if (filterVehicle == 0) {

        ui.errorAlert('Araç seçmediniz!', 'error');
    }
    else if (boxQuantity === 0) {
        ui.errorAlert('Kutu miktarını giriniz! ilk', 'error');

    } else if (palletQuantity > 0 && boxQuantity === 0) {
        ui.errorAlert('Kutu miktarını giriniz!', 'error');
    }
    else {
        request.post("Vendor/GetVendorOrders", { WarehouseCode: filterWarehouse[0] })
            .then(response => {
                ui.setTable(response)
                $('#exampleModalSizeXl').modal('show')
            })

    }
}

function createAsnLine() {

    //OrderASNHeader
    const warehouses = Array.from(document.querySelectorAll("#kt_select2_1>option"))
    const selectedWarehouseDesc = document.getElementById("select2-kt_select2_1-container").textContent;

    const vehicles = Array.from(document.querySelectorAll("#kt_select2_3>option"))
    const selectedVehicle = document.getElementById("select2-kt_select2_3-container").textContent;

    let filterVehicle = vehicles.filter((item) => selectedVehicle === item.textContent)
        .map((item) => {
            return item.value
        });

    let filterWarehouse = warehouses.filter((item) => selectedWarehouseDesc === item.textContent)
        .map((item) => {
            return item.value
        });




    //OrderASNLine
    const tableData = Array.from(document.querySelectorAll("#tableData>tr"))

    let OrderAsnLine = tableData.filter(item => parseInt(item.cells.getQuantity.lastElementChild.value) > 0)
        .map((item) => {

            return {
                itemCode: item.cells.itemCode.textContent.trim(),
                colorCode: item.cells.colorCode.textContent.trim(),
                itemDim1Code: item.cells.itemDim1Code.textContent.trim(),
                qty1: parseInt(item.cells.getQuantity.lastElementChild.value),
                itemTypeCode: item.cells.itemTypeCode.innerText.trim(),
                orderLineID: item.cells.orderLineID.innerText.trim(),
                deliveryDate: item.cells.deliveryDate.innerText.trim()
            }

        })

    console.log(OrderAsnLine)

    if (OrderAsnLine.length > 0) {
        const OrderAsnHeader = {
            ContainerTypeCode: filterVehicle[0],
            BoxQuantity: boxQuantity,
            PalletQuantity: palletQuantity,
            VendorCode: vendorCode,
            WarehouseCode: filterWarehouse[0],
            OrderAsnLines: Array.from(OrderAsnLine)
        }

        console.log(OrderAsnHeader)

        request.post("Vendor/CreateOrderAsn", OrderAsnHeader)
            .then(response => {
                $('#exampleModalSizeXl').modal('hide');
                ui.errorAlert("Asn fişi oluşturuldu", 'success')
                setTimeout(() => {
                    window.location.reload(true);
                }, 2500)


            }).catch(err => {
                ui.errorAlert("Bir hata oluştu", 'error')
                $('#exampleModalSizeXl').modal('hide')
            });


    } else {
        ui.errorAlert("Miktar girişi yapmadınız!", 'error')
    }



}