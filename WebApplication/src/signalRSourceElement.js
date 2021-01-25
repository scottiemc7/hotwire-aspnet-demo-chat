var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import { connectStreamSource, disconnectStreamSource } from "@hotwired/turbo";
import * as signalR from "@microsoft/signalr";
class TurboSignalRSourceElement extends HTMLElement {
    connectedCallback() {
        return __awaiter(this, void 0, void 0, function* () {
            connectStreamSource(this);
            this.connection = new signalR.HubConnectionBuilder()
                .withUrl(this.getAttribute("hub"))
                .build();
            this.connection.on(this.getAttribute("method"), (message) => {
                this.dispatchMessageEvent(message);
            });
            this.connection.start().then(() => {
                this.connection.invoke("ListenForMessages", this.getAttribute("room-id"));
            }).catch(err => console.log(err));
        });
    }
    disconnectedCallback() {
        disconnectStreamSource(this);
        if (this.connection)
            this.connection.stop();
    }
    dispatchMessageEvent(data) {
        const event = new MessageEvent("message", { data });
        return this.dispatchEvent(event);
    }
}
customElements.define("turbo-signalr-stream-source", TurboSignalRSourceElement);
