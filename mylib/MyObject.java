package mylib;

import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;

public class MyObject {

    private Map<String, String> data = new ConcurrentHashMap<>();

    public Map<String, String> getData() {
        return data;
    }

    public String getData(final String key) {
        return data.get(key);
    }

    public void setData(String key, String value) {
        data.put(key, value);
    }

    public void removeData(String key) {
        data.remove(key);
    }
}