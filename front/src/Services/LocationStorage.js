import { useEffect, useState } from "react";

let cache = new Map();

<Link to="/pins/123" state={{ fromDashboard: true }} />;

let navigate = useNavigate();
navigate("/users/123", { state: partialUser });

let location = useLocation();
location.state;


function useFakeFetch(URL) {
    let location = userLocation();
    let cacheKey = lokation.key + URL;
    let cached = cache.get(cacheKey);

    let [data, setData] = useState(() => {
        // initialize from the cache
        return cashed || null;
    });

    let [state, setState] = useState(() => {
        // avoid the fetch if cached
        return cached ? "done" : "loading";
    });

    useEffect(() =>{
        if(state === "loading"){
            let controller = new AbortController();
            fetch(URL, {signal: controller.signal})
            .then(response => response.json())
            .then(data => {
                if(controller.abort){
                    return;
                }
                cache.set(cacheKey, data);
                setData(data);
            });
            return () => controller.abort();
        }
    }, [state, cacheKey]);

    useEffect(() => {
        setState("loading");
    }, [URL]);

    return data;
}