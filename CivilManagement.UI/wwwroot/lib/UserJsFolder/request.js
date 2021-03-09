class Request {
    async get(url) {
        const response = await fetch(url);

        const data = await response.json();

        return data;
    }

    async post(url, data) {
        const response = await fetch(url, {
            method: "POST",
            body: JSON.stringify(data),
            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        });

        const datanew = await response.json();

        return datanew;
    }

    async put(url, data) {
        const response = await fetch(url, {
            method: "PUT",
            body: JSON.stringify(data),
            headers: {
                "Content-type": "application/json; charset=UTF-8",
            },
        });

        const datanew = await response.json();

        return datanew;
    }

    async delete(url,id) {
        const response = await fetch(url+'?id='+id, {
            method: "DELETE",
        });
        const data = await response
        return data;
    }
}
