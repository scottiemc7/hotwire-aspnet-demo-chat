import {connectStreamSource, disconnectStreamSource} from "@hotwired/turbo"
import * as signalR from "@microsoft/signalr";

class TurboSignalRSourceElement extends HTMLElement {
    private connection: signalR.HubConnection;
    async connectedCallback() {
        connectStreamSource(this);

        this.connection = new signalR.HubConnectionBuilder()
            .withUrl(this.getAttribute("hub"))
            .build();

        this.connection.on(this.getAttribute("method"), (message: string) => {
            this.dispatchMessageEvent(message);
        });

        this.connection.start().then(() => {
            this.connection.invoke("ListenForMessages", this.getAttribute("room-id"));
        }).catch(err => console.log(err));
    }

    disconnectedCallback() {
        disconnectStreamSource(this)
        if (this.connection) this.connection.stop();
    }

    dispatchMessageEvent(data) {
         const event = new MessageEvent("message", { data })
         return this.dispatchEvent(event)
    }
}

customElements.define("turbo-signalr-stream-source", TurboSignalRSourceElement);