import React, {ButtonHTMLAttributes, useState} from 'react';
import "./../styles/start_delivery.css";
import ReactDOM from 'react-dom';
export const ShowDeliveryComponent = () => {
    const[products, setProducts] = useState([]);
    const baseUrl = "http://localhost:5024";

    const[createdOrder, setCreatedOrder] = useState({})
    //var createdOrder: DeliveryOrder= {} as DeliveryOrder;
    
    type Product = {
        Id: number,
        Name: string,
        UrlImage: string,
        Price: number
    }

    type ProductIdAndQt = {
        id: number;
        quantity: number;
    }
    type DeliveryOrder = {
        Id: number;
        ClientName: string;
        ClientSurname: string;
        Direction: string;
        City: string;
        Country: string;
        PayOption: number;
        TotalToPay: number;
        OrderStatus: number;
    }
    type DataForOrderCreation =
    {
        deliveryOrder: DeliveryOrder;
        productIdAndQtList: ProductIdAndQt[];
    }
    

    var dataForOrderCreation = {} as DataForOrderCreation

    const onQuantityProductChange = (
        inputId: string, 
        valueQuantity: string) =>
    {
        let prodId = parseInt(inputId.split("_")[1]);

        for(let indexDeliveryArray = 0; indexDeliveryArray < dataForOrderCreation.productIdAndQtList.length; indexDeliveryArray++){
            let order = dataForOrderCreation.productIdAndQtList[indexDeliveryArray];
            if(order.id == prodId){
                dataForOrderCreation.productIdAndQtList[indexDeliveryArray].quantity = parseInt(valueQuantity);
            }
        }
    }

    const productCheckboxChange = (
        productId: string, 
        value: string, 
        checked:boolean) =>
    {
        let prodId = parseInt(productId.split("_")[1]);

        let inputQuantity = document.getElementById("inputQuantityProduct_"+value) as HTMLInputElement;
        let divQuantityProductWithLabel = document.getElementById("divQuantityProductWithLabel_"+value) as HTMLDivElement;
        if(inputQuantity && divQuantityProductWithLabel){
            if(checked){
                inputQuantity.value = "1";
                inputQuantity.min = "1";
                inputQuantity.max = "100";
                divQuantityProductWithLabel.hidden = false;

                let orderToDelivery = 
                { 
                    id: prodId, 
                    quantity: parseInt(inputQuantity.value) 
                } as ProductIdAndQt;

                if(!dataForOrderCreation.productIdAndQtList){
                    dataForOrderCreation.productIdAndQtList = [] as ProductIdAndQt[];
                }
                dataForOrderCreation.productIdAndQtList.push(orderToDelivery);
            }else{
                inputQuantity.value = "0";
                inputQuantity.min = "0";
                inputQuantity.max = "0";
                divQuantityProductWithLabel.hidden = true;

                dataForOrderCreation.productIdAndQtList = dataForOrderCreation.productIdAndQtList.filter(order => order.id != prodId);
            }
        }
        
    }

    const startDelivery  = (e: React.MouseEvent<HTMLButtonElement>) => {
        let divOrderDetails = document.getElementById("divOrderDetails");
        let divProducts = document.getElementById("divProducts");
        let divBuy = document.getElementById("divBuy");
        let btnMakeOrder = document.getElementById("btnMakeOrder");
        if(divProducts && divBuy && btnMakeOrder && divOrderDetails){
            divProducts.hidden=false;
            divBuy.hidden=false;
            btnMakeOrder.hidden = false;
            divOrderDetails.hidden=false;
        }
        
        let button = e.target as HTMLButtonElement;
        button.hidden = true;
        getAllProducts();
    }

    function getAllProducts(){
        let xhr = new XMLHttpRequest();
        xhr.open("GET", baseUrl+"/api/Products/GetAllProducts", true);
        xhr.onload = function (e) {
            if (xhr.readyState === 4) {
                if (xhr.status === 200) {
                    let response = JSON.parse(xhr.responseText);

                    if(response != null && response.productsArray != null){
                        setProducts(response.productsArray);
                    }
                    
                } else {
                    console.error(xhr.statusText);
                }
            }
        };
        xhr.onerror = function (e) {
            console.error(xhr.statusText);
        };
        xhr.send(null);
    }

    function getValueOfCheckedRadioButton(radiobuttons: NodeListOf<HTMLInputElement>){
        for(let i = 0, length = radiobuttons.length - 1; i < length; i++) {
            if (radiobuttons[i].checked) {
              return radiobuttons[i].value;
            }
          }
    }

    const createOrder  = () => {
        if(dataForOrderCreation.productIdAndQtList &&
            dataForOrderCreation.productIdAndQtList.length > 0){
            if (window.confirm('Are you sure you want to proceed your order?')) {
                let divBuyProcess = document.getElementById("divBuyProcess");
                let divOrderView_step2 = document.getElementById("divOrderView_step2");
                if(divBuyProcess && divOrderView_step2){
                    divBuyProcess.hidden = true;
                    divOrderView_step2.hidden = false;
                }
                let txtClientName = document.getElementById("txtClientName") as HTMLInputElement;
                let txtClientSurname = document.getElementById("txtClientSurname") as HTMLInputElement;
                let txtDirection = document.getElementById("txtDirection") as HTMLInputElement;
                let txtCity = document.getElementById("txtCity") as HTMLInputElement;
                let txtCountry = document.getElementById("txtCountry") as HTMLInputElement;
                let radiosPayOption = document.getElementsByName("payOption") as NodeListOf<HTMLInputElement>;
                if(txtClientName && 
                    txtClientSurname && 
                    txtDirection && 
                    txtCity &&
                    txtCountry && 
                    radiosPayOption){
                }
                let radioButtonValue = getValueOfCheckedRadioButton(radiosPayOption) as string;
                let newDeliveryOrder: DeliveryOrder = {} as DeliveryOrder;
                newDeliveryOrder.ClientName = txtClientName.value;
                newDeliveryOrder.ClientSurname = txtClientSurname.value;
                newDeliveryOrder.Direction = txtDirection.value;
                newDeliveryOrder.City = txtCity.value;
                newDeliveryOrder.Country = txtCountry.value;
                newDeliveryOrder.PayOption = parseInt(radioButtonValue);
                newDeliveryOrder.TotalToPay = 0;

                for(let index = 0; index < dataForOrderCreation.productIdAndQtList.length; index++){
                    let actualProductIdAndQt = dataForOrderCreation.productIdAndQtList[index];

                    let productFound = products.find((prod) => {return (prod as Product).Id == actualProductIdAndQt.id});
                    if(productFound){
                        let product = productFound as Product;
                        newDeliveryOrder.TotalToPay += product.Price * actualProductIdAndQt.quantity;
                    }
                }

                dataForOrderCreation.deliveryOrder = newDeliveryOrder;
                console.info(dataForOrderCreation);
                sendOrderToCreate();
            } else {
                // User do not confirm to do the order -> Do nothing
            }
        }else{
            alert("First you must to select at least one product to order");
        }
        
        
    }

    function sendOrderToCreate(){
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function() {
            if (this.readyState == 4 && this.status == 200) {
                let response = JSON.parse(this.responseText);
                let createdOrder = {} as DeliveryOrder;
                createdOrder.Id = response;
                setCreatedOrder(createdOrder);
                window.setInterval(
                    function(){
                        getOrderById(createdOrder.Id)
                      }, 10000);
            }
        };
        xhttp.open("POST", baseUrl+"/api/DeliveryOrder/CreateOrder", true);
        xhttp.setRequestHeader("Content-Type", "application/json");
        xhttp.send(JSON.stringify(dataForOrderCreation));
    }

    function getOrderById(orderId: number){
        let xhr = new XMLHttpRequest();
        xhr.open("GET", baseUrl+"/api/DeliveryOrder/GetDeliveryOrderById?orderId=" + orderId, true);
        xhr.onload = function (e) {
            if (xhr.readyState === 4) {
                if (xhr.status === 200) {
                    let response = JSON.parse(xhr.responseText);

                    if(response){
                        setCreatedOrder(response);
                    }
                    
                } else {
                    console.error(xhr.statusText);
                }
            }
        };
        xhr.onerror = function (e) {
            console.error(xhr.statusText);
        };
        xhr.send(null);
    }

    return (
<div id="deliveryDiv">
    <div id="divBuyProcess">
        <button id="buttonStartDelivery" className="standardButton" onClick={e => startDelivery(e)}>Click here to start your delivery!</button>
        <div id="divOrderDetails" hidden={true}>
            <h2>Please, fullfill your order details:</h2>
            <div>
                <label id="labelClientName">Your name:</label>
                <input type="text" id="txtClientName"/>
            </div>
            <div>
                <label id="labelClientName">Your surname:</label>
                <input type="text" id="txtClientSurname"/>
            </div>
            <div>
                <label id="labelDirection">Direction:</label>
                <input type="text" id="txtDirection"/>
            </div>
            <div>
                <label id="labelCity">City:</label>
                <input type="text" id="txtCity"/>
                
            </div>
            <div>
                <label id="labelCountry">Country:</label>
                <input type="text" id="txtCountry"/>
            </div>
            <div>
                <fieldset>
                    <legend>Pay option:</legend>
                    <label htmlFor="radioByCash">By cash:</label><input type="radio" id="radioByCash" name = "payOption" value="1" defaultChecked/>
                    <label htmlFor="radioByCard" >By card:</label><input type="radio" id="radioByCard" name = "payOption" value="2"/>
                </fieldset>
            </div>
        </div>
        <div id="divProducts" hidden={true}>
            {products.map((actualProduct, index)=>
            (
                <article key={(actualProduct as Product).Id}>
                    <div className='divSuperiorArticle'>
                        <img src={(actualProduct as Product).UrlImage} height={100} width={100} />
                        <div className='divQuantityProduct'>
                            <div className='divQuantityProductWithLabel' id={"divQuantityProductWithLabel_"+(actualProduct as Product).Id} hidden={true}>
                                <label>Quantity:</label>
                                <input type="number" defaultValue={0} min={0} max={0} id={"inputQuantityProduct_" + (actualProduct as Product).Id} onChange={e => onQuantityProductChange(e.target.id, e.target.value)} pattern="^[0-9]*$"/>
                            </div>
                        </div>
                    </div>
                    <div>
                        <label>Price per unit:</label> <label>{(actualProduct as Product).Price}€</label>
                    </div>
                    <div>
                        <input type="checkbox" id={"product_"+(actualProduct as Product).Id} value={(actualProduct as Product).Id} onChange={e => productCheckboxChange(e.target.id, e.target.value, e.target.checked)}/>
                        <label htmlFor={"product_"+(actualProduct as Product).Id}>{(actualProduct as Product).Name}</label>
                    </div>
                    
                </article>
            ))}
            
        </div>
        <div id="divBuy" hidden={true}>
            <button id="btnMakeOrder" className='standardButton' hidden={true} onClick={createOrder}>Make your order!</button>
        </div>
    </div>

    <div id="divOrderView_step2" hidden={true}>
        <div>
            
            <label>Preparing: </label><label className={
                (createdOrder as DeliveryOrder).OrderStatus==1 ? "processing" : "checkedOK"
            }>
                {(createdOrder as DeliveryOrder).OrderStatus==1 ? "▶" : "✓"}</label>
        </div>
        <div>
            <label>Going to the destination: </label><label className={
                (createdOrder as DeliveryOrder).OrderStatus==1 
                ? "notReady" 
                : (createdOrder as DeliveryOrder).OrderStatus==2 
                    ? "processing" 
                    : "checkedOK"
            }>{
                (createdOrder as DeliveryOrder).OrderStatus==1 
                ? "✗" 
                : (createdOrder as DeliveryOrder).OrderStatus==2 
                    ? "▶" 
                    : "✓"
            }</label>
        </div>
        <div>
            <label>Delivered: </label><label className={
                (createdOrder as DeliveryOrder).OrderStatus>=3 
                ? "checkedOK" 
                : "notReady"
            }>{
                (createdOrder as DeliveryOrder).OrderStatus>=3 
                ? "✓" 
                : "✗"
            }</label>
        </div>
    </div>
    
</div>
    );
}