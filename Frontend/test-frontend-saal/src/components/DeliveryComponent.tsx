import React, {ButtonHTMLAttributes, useState} from 'react';
import "./../styles/start_delivery.css";
export const ShowDeliveryComponent = () => {

    type OrderToDelivery = {
        productId: number;
        quantity: number;
    }

    var orderToDeliveryArray = [] as OrderToDelivery[]

    function findTheOrderByProductId(order: OrderToDelivery, prodId: number){
        return order.productId== prodId;
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
    }



    const productCheckboxChange  = (
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
                    productId: prodId, quantity: parseInt(inputQuantity.value) 
                } as OrderToDelivery;
                orderToDeliveryArray.push(orderToDelivery)

            }else{
                inputQuantity.value = "0";
                inputQuantity.min = "0";
                inputQuantity.max = "0";
                divQuantityProductWithLabel.hidden = true;

                

                orderToDeliveryArray = orderToDeliveryArray.filter(order => order.productId != prodId);
            }
        }
        
    }

    const onQuantityProductChange = (
        inputId: string, 
        valueQuantity: string) =>
    {
        let prodId = parseInt(inputId.split("_")[1]);

        for (let indexDeliveryArray = 0; indexDeliveryArray<orderToDeliveryArray.length; indexDeliveryArray++){
            let order = orderToDeliveryArray[indexDeliveryArray];
            if(order.productId == prodId){
                orderToDeliveryArray[indexDeliveryArray].quantity = parseInt(valueQuantity);
            }
        }
    }

    const createOrder  = () => {
        if(orderToDeliveryArray.length > 0){
            if (window.confirm('Are you sure you want to proceed your order?')) {
                let divBuyProcess = document.getElementById("divBuyProcess");
                let divOrderView_step2 = document.getElementById("divOrderView_step2");
                if(divBuyProcess && divOrderView_step2){
                    divBuyProcess.hidden = true;
                    divOrderView_step2.hidden = false;
                }
                console.log(orderToDeliveryArray);
            } else {
                // Do nothing
            }
        }else{
            alert("First you must to select at least one product to order");
        }
        
        
    }

    return (
<div id="deliveryDiv">
    <div id="divBuyProcess">
        <button id="buttonStartDelivery" className="standardButton" onClick={e => startDelivery(e)}>Click here to start your delivery!</button>
        <div id="divOrderDetails" hidden={true}>
            <h2>Please, fullfill your order details:</h2>
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
            <article>
                <div className='divSuperiorArticle'>
                    <img src="https://cookinglsl.com/wp-content/uploads/2014/11/whole-roasted-chicken-with-potatoes-2-1.jpg" height={100} width={100} />
                    <div className='divQuantityProduct'>
                        <div className='divQuantityProductWithLabel' id="divQuantityProductWithLabel_1" hidden={true}>
                            <label>Quantity:</label>
                            <input type="number" defaultValue={0} min={0} max={0} id="inputQuantityProduct_1" onChange={e => onQuantityProductChange(e.target.id, e.target.value)}/>
                        </div>
                    </div>
                </div>
                <div>
                    <label>Price per unit:</label> <label>10€</label>
                </div>
                <div>
                    <input type="checkbox" id="product_1" value="1" onChange={e => productCheckboxChange(e.target.id, e.target.value, e.target.checked)}/>
                    <label htmlFor="product_1">Chicken with potatoes</label>
                </div>
                
            </article>

            
        </div>
        <div id="divBuy" hidden={true}>
            <button id="btnMakeOrder" className='standardButton' hidden={true} onClick={createOrder}>Make your order!</button>
        </div>
    </div>

    <div id="divOrderView_step2" hidden={true}>
        <div>
            <label>Preparing: </label><label className='checkedOK'>✓</label>
        </div>
        <div>
            <label>Going to the destination: </label><label className="processing">▶</label>
        </div>
        <div>
            <label>Delivered: </label><label className='notReady'>✗</label>
        </div>
        
    </div>
    
</div>
    );
}