class UI {
    setTable(data) {
        const tbody = document.getElementById("tableData");
        tbody.innerHTML = "";

        data.forEach(el => {
            tbody.innerHTML += ` <tr>
                                                <td id='orderNumber'>
                                                    ${el.orderNumber}
                                                </td>
                                                <td id='warehouseDescription'>
                                                    ${el.warehouseDescription}
                                                </td>
                                                <td id='itemCode'>
                                                    ${el.itemCode}
                                                </td>
                                                <td id='itemDescription'>
                                                   ${el.itemDescription}
                                                </td>
                                                <td id='colorCode'>
                                                   ${el.colorCode}
                                                </td>
                                                <td id='itemDim1Code'>
                                                   ${el.itemDim1Code}
                                                </td>
                                                <td id='qty1'>
                                                   ${el.qty1}
                                                </td>
                                                <td id='remainingOrderQty1'>
                                                   ${el.remainingOrderQty1}
                                                </td>
                                                <td id='getQuantity'>
                                                    <input class="form-control" type="number" value="0">
                                                </td>
                                                <td hidden id='itemTypeCode'>
                                                    ${el.itemTypeCode}
                                                </td>
                                                <td hidden id='orderLineID'>
                                                    ${el.orderLineID}
                                                </td>
                                                <td hidden id='deliveryDate'>
                                                    ${el.deliveryDate}
                                                </td>
                                                
                                            </tr>`
        })
    }

    errorAlert(message, icon) {
        if (icon === 'error') {
            Swal.fire({
                icon: icon,
                title: 'Oops...',
                text: message,
                timer: 5000
            })
        } else {
            Swal.fire({
                icon: icon,
                text: message,
                timer: 5000
            })
        }
    }
    alert(message, icon) {
        if (icon === 'error') {
            Swal.fire({
                icon: icon,
                title: 'Oops...',
                text: message
            })
        } else {
            Swal.fire({
                icon: icon,
                text: message
            })
        }
    }

    deleteQuestion() {

       return new Promise((resolve, reject) => {
            swal.fire({
                title: 'Silmek istediğinizden emin misiniz?',
                text: "Bu işlem geri alınamaz!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Evet, Sil!',
                cancelButtonText: 'Hayır, Vazgeç!'
            }).then((result) => {
                if (result.value) {
                    resolve(true);
                }
            });

        })
       

      

    }
}