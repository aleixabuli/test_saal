import React from 'react';
import './styles/App.css';
import {ShowHeaderComponent} from "./components/MainHeader";
import { ShowDeliveryComponent } from './components/DeliveryComponent';

function App() {
  return (
    <div id="divApp">
      <ShowHeaderComponent/>
      <ShowDeliveryComponent/>
    </div>
  );
}

export default App;
