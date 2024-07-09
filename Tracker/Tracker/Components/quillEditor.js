window.quillEditor = {
  init: function (elementId, content) {
    var quill = new Quill("#" + elementId, {
      theme: "snow",
    });
    quill.root.innerHTML = content || "";

    quill.on("text-change", function () {
      DotNet.invokeMethodAsync(
        "Tracker",
        "UpdateContent",
        quill.root.innerHTML
      );
    });

    return {
      setContent: function (content) {
        quill.root.innerHTML = content;
      },
      getContent: function () {
        return quill.root.innerHTML;
      },
    };
  },
};
